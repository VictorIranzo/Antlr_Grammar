package com.intigua.antlr4.autosuggest;

import java.net.MalformedURLException;
import java.util.Collection;

public class Program {
    public static void main(String[] args) throws ClassNotFoundException, MalformedURLException {
        LexerAndParserFactory lexerAndParserFactory = new ReflectionLexerAndParserFactory(args[0], args[1]);
        Collection<String> suggestions = new AutoSuggester(lexerAndParserFactory, args[2]).suggestCompletions();

        for (String suggestion: suggestions) {
            System.out.println(suggestion);
        }
    }
}
