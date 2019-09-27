namespace SuggestionsPurger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using QuickGraph;

    public static class Program
    {
        static void Main(string[] args)
        {
            ////Case1();
            Case2();

            Console.ReadLine();
        }

        private static void Case1()
        {
            Stack<Suggestion> writtenRule = new Stack<Suggestion>();

            writtenRule.Push(new Suggestion("Si", "introIf"));
            writtenRule.Push(new Suggestion("es vegetariano", "boolAttbo"));

            List<Suggestion> wrongSuggestions = new List<Suggestion>()
            {
                new Suggestion(")", "closeParenthesis")
            };

            // In reverse direction!
            List<(string Source, string Target)> edgesToCreate = new List<(string Source, string Target)>()
            {
                ("openParenthesis", "introIf"),
                ("boolAttbo", "introIf"),
                ("boolAttbo", "openParenthesis"),
                ("closeParenthesis", "boolAttbo"),
            };

            PurgueSuggestions(writtenRule, wrongSuggestions, edgesToCreate);
        }

        private static void Case2()
        {
            Stack<Suggestion> writtenRule = new Stack<Suggestion>();

            writtenRule.Push(new Suggestion("Si", "introIf"));
            writtenRule.Push(new Suggestion("presión", "numericAttbo"));
            writtenRule.Push(new Suggestion("es igual a", "equals"));

            List<Suggestion> wrongSuggestions = new List<Suggestion>()
            {
                new Suggestion("velocidad", "otherNumericAttbo"),
                new Suggestion("apellido", "otherStringAttbo")
            };

            // In reverse direction!
            List<(string Source, string Target)> edgesToCreate = new List<(string Source, string Target)>()
            {
                ("stringAttbo", "introIf"),
                ("numericAttbo", "introIf"),
                ("equals", "numericAttbo"),
                ("equals", "stringAttbo"),
                ("otherNumericAttbo", "equals"),
                ("otherStringAttbo", "equals"),
            };

            PurgueSuggestions(writtenRule, wrongSuggestions, edgesToCreate);
        }

        private static void PurgueSuggestions(Stack<Suggestion> writtenRule, List<Suggestion> wrongSuggestions, List<(string Source, string Target)> edgesToCreate)
        {
            AdjacencyGraph<NumberedVertex, UndirectedEdge<NumberedVertex>> graph = CreateGraph(edgesToCreate);

            List<Suggestion> correctSuggestions = new List<Suggestion>();

            // TODO: Optimize to delete all the tokens of the same rule in a unique step.
            foreach (string ruleToEvaluate in wrongSuggestions.Select(s => s.Rule).Distinct())
            {
                if (ruleToEvaluate == "introIf")
                {
                    correctSuggestions.AddRange(wrongSuggestions.Where(s => s.Rule == ruleToEvaluate));

                    break;
                }

                Stack<Suggestion> clonedRuleStack = writtenRule.Clone();

                NumberedVertex currentRule = new NumberedVertex(ruleToEvaluate);

                while (clonedRuleStack.Count > 0)
                {
                    string ruleToSearch = clonedRuleStack.Pop().Rule;

                    // Esto debería funcionar.
                    bool a = graph.TryGetOutEdges(currentRule, out IEnumerable<UndirectedEdge<NumberedVertex>> outEdges);

                    NumberedVertex ruleToNavigate = outEdges?.FirstOrDefault(nv => nv.Target.Rule == ruleToSearch)?.Target;

                    if (ruleToNavigate == null)
                    {
                        // It is a wrong suggestion because introIf is not reached.
                        break;
                    }

                    if (ruleToSearch == "introIf")
                    {
                        // Reached first item of the grammar, so it is valid.
                        correctSuggestions.AddRange(wrongSuggestions.Where(s => s.Rule == ruleToEvaluate));

                        break;
                    }

                    // Moves to the next rule to check.
                    currentRule = ruleToNavigate;
                }
            }

            correctSuggestions.ForEach(s => Console.WriteLine(s));
        }

        // All the vertices in the graph must have as output degree a maximum value of 1 in order to be valid for suggestions.
        public static AdjacencyGraph<NumberedVertex, UndirectedEdge<NumberedVertex>> CreateGraph(IEnumerable<(string Source, string Target)> edges)
        {
            AdjacencyGraph<NumberedVertex, UndirectedEdge<NumberedVertex>> graph = new AdjacencyGraph<NumberedVertex, UndirectedEdge<NumberedVertex>>();

            foreach ((string Source, string Target) in edges)
            {
                NumberedVertex sourceVertex;
                NumberedVertex targetVertex = graph.Vertices.FirstOrDefault(nv => nv.Rule == Target) ?? new NumberedVertex(Target, 0);

                // If the vertex exists, we duplicate it incremeting in one its number. Take care with the LastOrDefault invocation.
                if (graph.Vertices.LastOrDefault(nv => nv.Rule == Source) is NumberedVertex existingVertex)
                {
                    sourceVertex = new NumberedVertex(Source, existingVertex.Number + 1);
                }
                else
                {
                    sourceVertex = new NumberedVertex(Source, 0);
                }

                graph.AddVerticesAndEdge(new UndirectedEdge<NumberedVertex>(sourceVertex, targetVertex));
            }

            return graph;
        }

        public static Stack<T> Clone<T>(this Stack<T> stack)
        {
            return new Stack<T>(stack.Reverse());
        }
    }

    public class Suggestion
    {
        public Suggestion(string token, string rule)
        {
            Token = token;
            Rule = rule;
        }

        public string Token { get; set; }

        public string Rule { get; set; }
    }

    public class NumberedVertex
    {
        public NumberedVertex(string rule, int number)
        {
            Rule = rule;
            Number = number;
        }

        public NumberedVertex(string rule)
        {
            Rule = rule;
        }

        public string Rule { get; set; }

        public int Number { get; set; }

        // OJO con esto.
        public override bool Equals(object obj)
        {
            var vertex = obj as NumberedVertex;
            return vertex != null &&
                   this.Rule == vertex.Rule;
        }
    }
}