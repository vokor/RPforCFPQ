using System;
using System.Runtime.InteropServices;
using No.Comparers;
using Parser;
using Parser.Grammars;
using Parser.Graphs;
using Parser.Relational;
using Parser.Valuations;

namespace RPforCFPQ
{
    class Program
    {
        static void Main(string[] args)
        {
            IGraphEngineFactory engineFactory = new DictionaryGraphEngineFactory();
            IAtomEngineFactory atomEngineFactory = new DagAtomEngineFactory(engineFactory);
            
            DictionaryGraphEngineFactory dictionaryGraphEngineFactory = new DictionaryGraphEngineFactory();
            
            IGraphEngineFactory engineFactory1 = new DictionaryGraphEngineFactory();
            DagWrapEngineFactory dagWrapEngineFactory = new DagWrapEngineFactory(engineFactory1);
            
            CommutativeWrapEngineFactory commutativeWrapEngineFactory = new CommutativeWrapEngineFactory(dagWrapEngineFactory);
            IRelationEngineFactory relationEngineFactory =
                new DagRelationEngineFactory(commutativeWrapEngineFactory, dictionaryGraphEngineFactory);
            IRelationOperantFactory relationOperantFactory = new RelationOperantFactory(relationEngineFactory);

            AtomicOptimization[] atomicOptimizations = new AtomicOptimization[0];
            
            ParserGenerator parserGenerator = 
                new RelationalParserGenerator(atomEngineFactory, 
                    relationOperantFactory, false, atomicOptimizations);

            //List<Char[]> inputs = new List<char[]>();
            //inputs.Add(new []{'(', '(', ')', '(', ')', ')'});
            
            BooleanSemiring  valuationSemiring = new BooleanSemiring();
            var parser = parserGenerator.CreateParser(SampleGrammar.Parentheses, valuationSemiring);

            var result = parser.Run("((()())", () =>
            {
                //Console.WriteLine("ok");
            });

            if (result)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
} 