using System;
using System.Runtime.InteropServices;
using No.Comparers;
using Parser;
using Parser.Grammars;
using Parser.Graphs;
using Parser.Relational;
using Parser.Utilities;
using System.Collections.Generic;

namespace RPforCFPQ
{
    class Program
    {
        static void Main(string[] args)
        {
            IGraphEngineFactory engineFactory = new DictionaryGraphEngineFactory();
            IAtomEngineFactory atomEngineFactory = new DagAtomEngineFactory(engineFactory);
            
            DictionaryGraphEngineFactory dictionaryGraphEngineFactory = new DictionaryGraphEngineFactory();
            CommutativeWrapEngineFactory commutativeWrapEngineFactory =new CommutativeWrapEngineFactory(null);
            IRelationEngineFactory relationEngineFactory =
                new DagRelationEngineFactory(commutativeWrapEngineFactory, dictionaryGraphEngineFactory);
            IRelationOperantFactory relationOperantFactory = new RelationOperantFactory(relationEngineFactory);

            AtomicOptimization[] atomicOptimizations = new AtomicOptimization[0];
            
            ParserGenerator parserGenerator = 
                new RelationalParserGenerator(atomEngineFactory, 
                    relationOperantFactory, false, atomicOptimizations);

            List<Char[]> inputs = new List<char[]>();
            inputs.Add(new []{'(', '(', ')', '(', ')', ')'});
            
            IValuationSemiring<TValue>
            parserGenerator.CreateParser(SampleGrammar.Parentheses, )
        }
    }
} 