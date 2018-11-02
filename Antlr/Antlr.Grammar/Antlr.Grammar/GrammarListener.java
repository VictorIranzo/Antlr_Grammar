// Generated from .\Grammar.g4 by ANTLR 4.7.1
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link GrammarParser}.
 */
public interface GrammarListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link GrammarParser#regla}.
	 * @param ctx the parse tree
	 */
	void enterRegla(GrammarParser.ReglaContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#regla}.
	 * @param ctx the parse tree
	 */
	void exitRegla(GrammarParser.ReglaContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#condicion}.
	 * @param ctx the parse tree
	 */
	void enterCondicion(GrammarParser.CondicionContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#condicion}.
	 * @param ctx the parse tree
	 */
	void exitCondicion(GrammarParser.CondicionContext ctx);
}