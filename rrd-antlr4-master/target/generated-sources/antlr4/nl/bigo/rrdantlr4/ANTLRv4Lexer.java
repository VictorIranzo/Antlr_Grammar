// Generated from nl\bigo\rrdantlr4\ANTLRv4Lexer.g4 by ANTLR 4.1
package nl.bigo.rrdantlr4;
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class ANTLRv4Lexer extends Lexer {
	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		TOKEN_REF=1, RULE_REF=2, LEXER_CHAR_SET=3, DOC_COMMENT=4, BLOCK_COMMENT=5, 
		LINE_COMMENT=6, BEGIN_ARG_ACTION=7, OPTIONS=8, TOKENS=9, IMPORT=10, FRAGMENT=11, 
		LEXER=12, PARSER=13, GRAMMAR=14, PROTECTED=15, PUBLIC=16, PRIVATE=17, 
		RETURNS=18, LOCALS=19, THROWS=20, CATCH=21, FINALLY=22, MODE=23, COLON=24, 
		COLONCOLON=25, COMMA=26, SEMI=27, LPAREN=28, RPAREN=29, RARROW=30, LT=31, 
		GT=32, ASSIGN=33, QUESTION=34, STAR=35, PLUS=36, PLUS_ASSIGN=37, OR=38, 
		DOLLAR=39, DOT=40, RANGE=41, AT=42, POUND=43, NOT=44, RBRACE=45, ID=46, 
		INT=47, STRING_LITERAL=48, UNTERMINATED_STRING_LITERAL=49, WS=50, ERRCHAR=51, 
		ARG_ACTION=52, UNTERMINATED_ARG_ACTION=53, ACTION=54, UNTERMINATED_ACTION=55, 
		UNTERMINATED_CHAR_SET=56, BEGIN_ACTION=57;
	public static final int ArgAction = 1;
	public static final int Action = 2;
	public static final int LexerCharSet = 3;
	public static String[] modeNames = {
		"DEFAULT_MODE", "ArgAction", "Action", "LexerCharSet"
	};

	public static final String[] tokenNames = {
		"<INVALID>",
		"TOKEN_REF", "RULE_REF", "LEXER_CHAR_SET", "DOC_COMMENT", "BLOCK_COMMENT", 
		"LINE_COMMENT", "BEGIN_ARG_ACTION", "OPTIONS", "TOKENS", "'import'", "'fragment'", 
		"'lexer'", "'parser'", "'grammar'", "'protected'", "'public'", "'private'", 
		"'returns'", "'locals'", "'throws'", "'catch'", "'finally'", "'mode'", 
		"':'", "'::'", "','", "';'", "'('", "')'", "'->'", "'<'", "'>'", "'='", 
		"'?'", "'*'", "'+'", "'+='", "'|'", "'$'", "'.'", "'..'", "'@'", "'#'", 
		"'~'", "RBRACE", "ID", "INT", "STRING_LITERAL", "UNTERMINATED_STRING_LITERAL", 
		"WS", "ERRCHAR", "ARG_ACTION", "UNTERMINATED_ARG_ACTION", "ACTION", "UNTERMINATED_ACTION", 
		"UNTERMINATED_CHAR_SET", "BEGIN_ACTION"
	};
	public static final String[] ruleNames = {
		"DOC_COMMENT", "BLOCK_COMMENT", "LINE_COMMENT", "BEGIN_ARG_ACTION", "BEGIN_ACTION", 
		"OPTIONS", "TOKENS", "IMPORT", "FRAGMENT", "LEXER", "PARSER", "GRAMMAR", 
		"PROTECTED", "PUBLIC", "PRIVATE", "RETURNS", "LOCALS", "THROWS", "CATCH", 
		"FINALLY", "MODE", "COLON", "COLONCOLON", "COMMA", "SEMI", "LPAREN", "RPAREN", 
		"RARROW", "LT", "GT", "ASSIGN", "QUESTION", "STAR", "PLUS", "PLUS_ASSIGN", 
		"OR", "DOLLAR", "DOT", "RANGE", "AT", "POUND", "NOT", "RBRACE", "ID", 
		"NameChar", "NameStartChar", "INT", "STRING_LITERAL", "UNTERMINATED_STRING_LITERAL", 
		"ESC_SEQ", "UNICODE_ESC", "HEX_DIGIT", "WS", "ERRCHAR", "NESTED_ARG_ACTION", 
		"ARG_ACTION_ESCAPE", "ARG_ACTION_STRING_LITERAL", "ARG_ACTION_CHAR_LITERAL", 
		"ARG_ACTION", "UNTERMINATED_ARG_ACTION", "ARG_ACTION_CHAR", "NESTED_ACTION", 
		"ACTION_ESCAPE", "ACTION_STRING_LITERAL", "ACTION_CHAR_LITERAL", "ACTION_COMMENT", 
		"ACTION", "UNTERMINATED_ACTION", "ACTION_CHAR", "LEXER_CHAR_SET_BODY", 
		"LEXER_CHAR_SET", "UNTERMINATED_CHAR_SET"
	};


		/** Track whether we are inside of a rule and whether it is lexical parser.
		 *  _currentRuleType==Token.INVALID_TYPE means that we are outside of a rule.
		 *  At the first sign of a rule name reference and _currentRuleType==invalid,
		 *  we can assume that we are starting a parser rule. Similarly, seeing
		 *  a token reference when not already in rule means starting a token
		 *  rule. The terminating ';' of a rule, flips this back to invalid type.
		 *
		 *  This is not perfect logic but works. For example, "grammar T;" means
		 *  that we start and stop a lexical rule for the "T;". Dangerous but works.
		 *
		 *  The whole point of this state information is to distinguish
		 *  between [..arg actions..] and [charsets]. Char sets can only occur in
		 *  lexical rules and arg actions cannot occur.
		 */
		private int _currentRuleType = Token.INVALID_TYPE;

		public int getCurrentRuleType() {
			return _currentRuleType;
		}

		public void setCurrentRuleType(int ruleType) {
			this._currentRuleType = ruleType;
		}

		protected void handleBeginArgAction() {
			if (inLexerRule()) {
				pushMode(LexerCharSet);
				more();
			}
			else {
				pushMode(ArgAction);
				more();
			}
		}

		@Override
		public Token emit() {
			if (_type == ID) {
				String firstChar = _input.getText(Interval.of(_tokenStartCharIndex, _tokenStartCharIndex));
				if (Character.isUpperCase(firstChar.charAt(0))) {
					_type = TOKEN_REF;
				} else {
					_type = RULE_REF;
				}

				if (_currentRuleType == Token.INVALID_TYPE) { // if outside of rule def
					_currentRuleType = _type;                 // set to inside lexer or parser rule
				}
			}
			else if (_type == SEMI) {                  // exit rule def
				_currentRuleType = Token.INVALID_TYPE;
			}

			return super.emit();
		}

		private boolean inLexerRule() {
			return _currentRuleType == TOKEN_REF;
		}
		private boolean inParserRule() { // not used, but added for clarity
			return _currentRuleType == RULE_REF;
		}


	public ANTLRv4Lexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "ANTLRv4Lexer.g4"; }

	@Override
	public String[] getTokenNames() { return tokenNames; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	@Override
	public void action(RuleContext _localctx, int ruleIndex, int actionIndex) {
		switch (ruleIndex) {
		case 1: BLOCK_COMMENT_action((RuleContext)_localctx, actionIndex); break;

		case 2: LINE_COMMENT_action((RuleContext)_localctx, actionIndex); break;

		case 3: BEGIN_ARG_ACTION_action((RuleContext)_localctx, actionIndex); break;

		case 4: BEGIN_ACTION_action((RuleContext)_localctx, actionIndex); break;

		case 52: WS_action((RuleContext)_localctx, actionIndex); break;

		case 53: ERRCHAR_action((RuleContext)_localctx, actionIndex); break;

		case 54: NESTED_ARG_ACTION_action((RuleContext)_localctx, actionIndex); break;

		case 55: ARG_ACTION_ESCAPE_action((RuleContext)_localctx, actionIndex); break;

		case 56: ARG_ACTION_STRING_LITERAL_action((RuleContext)_localctx, actionIndex); break;

		case 57: ARG_ACTION_CHAR_LITERAL_action((RuleContext)_localctx, actionIndex); break;

		case 58: ARG_ACTION_action((RuleContext)_localctx, actionIndex); break;

		case 59: UNTERMINATED_ARG_ACTION_action((RuleContext)_localctx, actionIndex); break;

		case 60: ARG_ACTION_CHAR_action((RuleContext)_localctx, actionIndex); break;

		case 61: NESTED_ACTION_action((RuleContext)_localctx, actionIndex); break;

		case 62: ACTION_ESCAPE_action((RuleContext)_localctx, actionIndex); break;

		case 63: ACTION_STRING_LITERAL_action((RuleContext)_localctx, actionIndex); break;

		case 64: ACTION_CHAR_LITERAL_action((RuleContext)_localctx, actionIndex); break;

		case 65: ACTION_COMMENT_action((RuleContext)_localctx, actionIndex); break;

		case 66: ACTION_action((RuleContext)_localctx, actionIndex); break;

		case 67: UNTERMINATED_ACTION_action((RuleContext)_localctx, actionIndex); break;

		case 68: ACTION_CHAR_action((RuleContext)_localctx, actionIndex); break;

		case 69: LEXER_CHAR_SET_BODY_action((RuleContext)_localctx, actionIndex); break;

		case 70: LEXER_CHAR_SET_action((RuleContext)_localctx, actionIndex); break;

		case 71: UNTERMINATED_CHAR_SET_action((RuleContext)_localctx, actionIndex); break;
		}
	}
	private void BEGIN_ARG_ACTION_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 0: handleBeginArgAction(); break;
		}
	}
	private void ACTION_CHAR_LITERAL_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 17: more();  break;
		}
	}
	private void ERRCHAR_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 6: _channel = HIDDEN;  break;
		}
	}
	private void LEXER_CHAR_SET_BODY_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 21: more();  break;
		}
	}
	private void ARG_ACTION_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 11: popMode();  break;
		}
	}
	private void ACTION_CHAR_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 20: more();  break;
		}
	}
	private void BEGIN_ACTION_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 4: more(); pushMode(Action);  break;
		}
	}
	private void UNTERMINATED_ARG_ACTION_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 12: popMode();  break;
		}
	}
	private void ARG_ACTION_CHAR_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 13: more();  break;
		}
	}
	private void ARG_ACTION_CHAR_LITERAL_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 10: more();  break;
		}
	}
	private void ACTION_ESCAPE_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 15: more();  break;
		}
	}
	private void BLOCK_COMMENT_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 2: _channel = HIDDEN;  break;
		}
	}
	private void LINE_COMMENT_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 3: _channel = HIDDEN;  break;
		}
	}
	private void ACTION_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 1: 
		            popMode();
		        	if ( _modeStack.size()>0 ) more(); // keep scarfing until outermost }
		             break;
		}
	}
	private void NESTED_ARG_ACTION_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 7: more(); pushMode(ArgAction);  break;
		}
	}
	private void UNTERMINATED_ACTION_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 19: popMode();  break;
		}
	}
	private void ACTION_COMMENT_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 18: more();  break;
		}
	}
	private void UNTERMINATED_CHAR_SET_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 23: popMode();  break;
		}
	}
	private void ARG_ACTION_ESCAPE_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 8: more();  break;
		}
	}
	private void WS_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 5: _channel = HIDDEN;  break;
		}
	}
	private void ARG_ACTION_STRING_LITERAL_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 9: more();  break;
		}
	}
	private void ACTION_STRING_LITERAL_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 16: more();  break;
		}
	}
	private void NESTED_ACTION_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 14: more(); pushMode(Action);  break;
		}
	}
	private void LEXER_CHAR_SET_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 22: popMode();  break;
		}
	}

	public static final String _serializedATN =
		"\3\uacf5\uee8c\u4f5d\u8b0d\u4a45\u78bd\u1b2f\u3378\2;\u022e\b\1\b\1\b"+
		"\1\b\1\4\2\t\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t"+
		"\4\n\t\n\4\13\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21"+
		"\t\21\4\22\t\22\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30"+
		"\t\30\4\31\t\31\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37"+
		"\t\37\4 \t \4!\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)"+
		"\4*\t*\4+\t+\4,\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63"+
		"\t\63\4\64\t\64\4\65\t\65\4\66\t\66\4\67\t\67\48\t8\49\t9\4:\t:\4;\t;"+
		"\4<\t<\4=\t=\4>\t>\4?\t?\4@\t@\4A\tA\4B\tB\4C\tC\4D\tD\4E\tE\4F\tF\4G"+
		"\tG\4H\tH\4I\tI\3\2\3\2\3\2\3\2\3\2\7\2\u009c\n\2\f\2\16\2\u009f\13\2"+
		"\3\2\3\2\3\2\5\2\u00a4\n\2\3\3\3\3\3\3\3\3\7\3\u00aa\n\3\f\3\16\3\u00ad"+
		"\13\3\3\3\3\3\3\3\5\3\u00b2\n\3\3\3\3\3\3\4\3\4\3\4\3\4\7\4\u00ba\n\4"+
		"\f\4\16\4\u00bd\13\4\3\4\3\4\3\5\3\5\3\5\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3"+
		"\7\3\7\3\7\3\7\3\7\3\7\7\7\u00d1\n\7\f\7\16\7\u00d4\13\7\3\7\3\7\3\b\3"+
		"\b\3\b\3\b\3\b\3\b\3\b\3\b\7\b\u00e0\n\b\f\b\16\b\u00e3\13\b\3\b\3\b\3"+
		"\t\3\t\3\t\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n\3\n\3\n\3\n\3\n\3\n\3\13\3"+
		"\13\3\13\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\r\3\r\3\r\3\r\3"+
		"\r\3\r\3\r\3\r\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\17"+
		"\3\17\3\17\3\17\3\17\3\17\3\17\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20"+
		"\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\22\3\22\3\22\3\22\3\22\3\22"+
		"\3\22\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\24\3\24\3\24\3\24\3\24\3\24"+
		"\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\26\3\26\3\26\3\26\3\26\3\27"+
		"\3\27\3\30\3\30\3\30\3\31\3\31\3\32\3\32\3\33\3\33\3\34\3\34\3\35\3\35"+
		"\3\35\3\36\3\36\3\37\3\37\3 \3 \3!\3!\3\"\3\"\3#\3#\3$\3$\3$\3%\3%\3&"+
		"\3&\3\'\3\'\3(\3(\3(\3)\3)\3*\3*\3+\3+\3,\3,\3-\3-\7-\u0180\n-\f-\16-"+
		"\u0183\13-\3.\3.\5.\u0187\n.\3/\3/\3\60\6\60\u018c\n\60\r\60\16\60\u018d"+
		"\3\61\3\61\3\61\7\61\u0193\n\61\f\61\16\61\u0196\13\61\3\61\3\61\3\62"+
		"\3\62\3\62\7\62\u019d\n\62\f\62\16\62\u01a0\13\62\3\63\3\63\3\63\3\63"+
		"\3\63\5\63\u01a7\n\63\3\64\3\64\3\64\3\64\3\64\5\64\u01ae\n\64\5\64\u01b0"+
		"\n\64\5\64\u01b2\n\64\5\64\u01b4\n\64\3\65\3\65\3\66\6\66\u01b9\n\66\r"+
		"\66\16\66\u01ba\3\66\3\66\3\67\3\67\3\67\3\67\38\38\38\38\39\39\39\39"+
		"\39\3:\3:\3:\3:\7:\u01d0\n:\f:\16:\u01d3\13:\3:\3:\3:\3:\3;\3;\3;\3;\3"+
		";\5;\u01de\n;\3;\3;\3<\3<\3<\3<\3=\3=\3=\3=\3>\3>\3>\3>\3?\3?\3?\3?\3"+
		"@\3@\3@\3@\3@\3A\3A\3A\3A\7A\u01fb\nA\fA\16A\u01fe\13A\3A\3A\3A\3A\3B"+
		"\3B\3B\3B\3B\5B\u0209\nB\3B\3B\3C\3C\5C\u020f\nC\3C\3C\3D\3D\3D\3E\3E"+
		"\3E\3E\3F\3F\3F\3F\3G\3G\3G\6G\u0221\nG\rG\16G\u0222\3G\3G\3H\3H\3H\3"+
		"H\3I\3I\3I\3I\4\u009d\u00abJ\6\6\1\b\7\4\n\b\5\f\t\2\16;\6\20\n\1\22\13"+
		"\1\24\f\1\26\r\1\30\16\1\32\17\1\34\20\1\36\21\1 \22\1\"\23\1$\24\1&\25"+
		"\1(\26\1*\27\1,\30\1.\31\1\60\32\1\62\33\1\64\34\1\66\35\18\36\1:\37\1"+
		"< \1>!\1@\"\1B#\1D$\1F%\1H&\1J\'\1L(\1N)\1P*\1R+\1T,\1V-\1X.\1Z/\1\\\60"+
		"\1^\2\1`\2\1b\61\1d\62\1f\63\1h\2\1j\2\1l\2\1n\64\7p\65\br\2\tt\2\nv\2"+
		"\13x\2\fz\66\r|\67\16~\2\17\u0080\2\20\u0082\2\21\u0084\2\22\u0086\2\23"+
		"\u0088\2\24\u008a8\3\u008c9\25\u008e\2\26\u0090\2\27\u0092\5\30\u0094"+
		":\31\6\2\3\4\5\f\4\2\f\f\17\17\5\2\13\f\16\17\"\"\7\2\62;aa\u00b9\u00b9"+
		"\u0302\u0371\u2041\u2042\17\2C\\c|\u00c2\u00d8\u00da\u00f8\u00fa\u0301"+
		"\u0372\u037f\u0381\u2001\u200e\u200f\u2072\u2191\u2c02\u2ff1\u3003\ud801"+
		"\uf902\ufdd1\ufdf2\uffff\3\2\62;\6\2\f\f\17\17))^^\n\2$$))^^ddhhppttv"+
		"v\5\2\62;CHch\4\2$$^^\3\2^_\u0244\2\6\3\2\2\2\2\b\3\2\2\2\2\n\3\2\2\2"+
		"\2\f\3\2\2\2\2\16\3\2\2\2\2\20\3\2\2\2\2\22\3\2\2\2\2\24\3\2\2\2\2\26"+
		"\3\2\2\2\2\30\3\2\2\2\2\32\3\2\2\2\2\34\3\2\2\2\2\36\3\2\2\2\2 \3\2\2"+
		"\2\2\"\3\2\2\2\2$\3\2\2\2\2&\3\2\2\2\2(\3\2\2\2\2*\3\2\2\2\2,\3\2\2\2"+
		"\2.\3\2\2\2\2\60\3\2\2\2\2\62\3\2\2\2\2\64\3\2\2\2\2\66\3\2\2\2\28\3\2"+
		"\2\2\2:\3\2\2\2\2<\3\2\2\2\2>\3\2\2\2\2@\3\2\2\2\2B\3\2\2\2\2D\3\2\2\2"+
		"\2F\3\2\2\2\2H\3\2\2\2\2J\3\2\2\2\2L\3\2\2\2\2N\3\2\2\2\2P\3\2\2\2\2R"+
		"\3\2\2\2\2T\3\2\2\2\2V\3\2\2\2\2X\3\2\2\2\2Z\3\2\2\2\2\\\3\2\2\2\2b\3"+
		"\2\2\2\2d\3\2\2\2\2f\3\2\2\2\2n\3\2\2\2\2p\3\2\2\2\3r\3\2\2\2\3t\3\2\2"+
		"\2\3v\3\2\2\2\3x\3\2\2\2\3z\3\2\2\2\3|\3\2\2\2\3~\3\2\2\2\4\u0080\3\2"+
		"\2\2\4\u0082\3\2\2\2\4\u0084\3\2\2\2\4\u0086\3\2\2\2\4\u0088\3\2\2\2\4"+
		"\u008a\3\2\2\2\4\u008c\3\2\2\2\4\u008e\3\2\2\2\5\u0090\3\2\2\2\5\u0092"+
		"\3\2\2\2\5\u0094\3\2\2\2\6\u0096\3\2\2\2\b\u00a5\3\2\2\2\n\u00b5\3\2\2"+
		"\2\f\u00c0\3\2\2\2\16\u00c3\3\2\2\2\20\u00c7\3\2\2\2\22\u00d7\3\2\2\2"+
		"\24\u00e6\3\2\2\2\26\u00ed\3\2\2\2\30\u00f6\3\2\2\2\32\u00fc\3\2\2\2\34"+
		"\u0103\3\2\2\2\36\u010b\3\2\2\2 \u0115\3\2\2\2\"\u011c\3\2\2\2$\u0124"+
		"\3\2\2\2&\u012c\3\2\2\2(\u0133\3\2\2\2*\u013a\3\2\2\2,\u0140\3\2\2\2."+
		"\u0148\3\2\2\2\60\u014d\3\2\2\2\62\u014f\3\2\2\2\64\u0152\3\2\2\2\66\u0154"+
		"\3\2\2\28\u0156\3\2\2\2:\u0158\3\2\2\2<\u015a\3\2\2\2>\u015d\3\2\2\2@"+
		"\u015f\3\2\2\2B\u0161\3\2\2\2D\u0163\3\2\2\2F\u0165\3\2\2\2H\u0167\3\2"+
		"\2\2J\u0169\3\2\2\2L\u016c\3\2\2\2N\u016e\3\2\2\2P\u0170\3\2\2\2R\u0172"+
		"\3\2\2\2T\u0175\3\2\2\2V\u0177\3\2\2\2X\u0179\3\2\2\2Z\u017b\3\2\2\2\\"+
		"\u017d\3\2\2\2^\u0186\3\2\2\2`\u0188\3\2\2\2b\u018b\3\2\2\2d\u018f\3\2"+
		"\2\2f\u0199\3\2\2\2h\u01a1\3\2\2\2j\u01a8\3\2\2\2l\u01b5\3\2\2\2n\u01b8"+
		"\3\2\2\2p\u01be\3\2\2\2r\u01c2\3\2\2\2t\u01c6\3\2\2\2v\u01cb\3\2\2\2x"+
		"\u01dd\3\2\2\2z\u01e1\3\2\2\2|\u01e5\3\2\2\2~\u01e9\3\2\2\2\u0080\u01ed"+
		"\3\2\2\2\u0082\u01f1\3\2\2\2\u0084\u01f6\3\2\2\2\u0086\u0208\3\2\2\2\u0088"+
		"\u020e\3\2\2\2\u008a\u0212\3\2\2\2\u008c\u0215\3\2\2\2\u008e\u0219\3\2"+
		"\2\2\u0090\u0220\3\2\2\2\u0092\u0226\3\2\2\2\u0094\u022a\3\2\2\2\u0096"+
		"\u0097\7\61\2\2\u0097\u0098\7,\2\2\u0098\u0099\7,\2\2\u0099\u009d\3\2"+
		"\2\2\u009a\u009c\13\2\2\2\u009b\u009a\3\2\2\2\u009c\u009f\3\2\2\2\u009d"+
		"\u009e\3\2\2\2\u009d\u009b\3\2\2\2\u009e\u00a3\3\2\2\2\u009f\u009d\3\2"+
		"\2\2\u00a0\u00a1\7,\2\2\u00a1\u00a4\7\61\2\2\u00a2\u00a4\7\2\2\3\u00a3"+
		"\u00a0\3\2\2\2\u00a3\u00a2\3\2\2\2\u00a4\7\3\2\2\2\u00a5\u00a6\7\61\2"+
		"\2\u00a6\u00a7\7,\2\2\u00a7\u00ab\3\2\2\2\u00a8\u00aa\13\2\2\2\u00a9\u00a8"+
		"\3\2\2\2\u00aa\u00ad\3\2\2\2\u00ab\u00ac\3\2\2\2\u00ab\u00a9\3\2\2\2\u00ac"+
		"\u00b1\3\2\2\2\u00ad\u00ab\3\2\2\2\u00ae\u00af\7,\2\2\u00af\u00b2\7\61"+
		"\2\2\u00b0\u00b2\7\2\2\3\u00b1\u00ae\3\2\2\2\u00b1\u00b0\3\2\2\2\u00b2"+
		"\u00b3\3\2\2\2\u00b3\u00b4\b\3\4\2\u00b4\t\3\2\2\2\u00b5\u00b6\7\61\2"+
		"\2\u00b6\u00b7\7\61\2\2\u00b7\u00bb\3\2\2\2\u00b8\u00ba\n\2\2\2\u00b9"+
		"\u00b8\3\2\2\2\u00ba\u00bd\3\2\2\2\u00bb\u00b9\3\2\2\2\u00bb\u00bc\3\2"+
		"\2\2\u00bc\u00be\3\2\2\2\u00bd\u00bb\3\2\2\2\u00be\u00bf\b\4\5\2\u00bf"+
		"\13\3\2\2\2\u00c0\u00c1\7]\2\2\u00c1\u00c2\b\5\2\2\u00c2\r\3\2\2\2\u00c3"+
		"\u00c4\7}\2\2\u00c4\u00c5\3\2\2\2\u00c5\u00c6\b\6\6\2\u00c6\17\3\2\2\2"+
		"\u00c7\u00c8\7q\2\2\u00c8\u00c9\7r\2\2\u00c9\u00ca\7v\2\2\u00ca\u00cb"+
		"\7k\2\2\u00cb\u00cc\7q\2\2\u00cc\u00cd\7p\2\2\u00cd\u00ce\7u\2\2\u00ce"+
		"\u00d2\3\2\2\2\u00cf\u00d1\t\3\2\2\u00d0\u00cf\3\2\2\2\u00d1\u00d4\3\2"+
		"\2\2\u00d2\u00d0\3\2\2\2\u00d2\u00d3\3\2\2\2\u00d3\u00d5\3\2\2\2\u00d4"+
		"\u00d2\3\2\2\2\u00d5\u00d6\7}\2\2\u00d6\21\3\2\2\2\u00d7\u00d8\7v\2\2"+
		"\u00d8\u00d9\7q\2\2\u00d9\u00da\7m\2\2\u00da\u00db\7g\2\2\u00db\u00dc"+
		"\7p\2\2\u00dc\u00dd\7u\2\2\u00dd\u00e1\3\2\2\2\u00de\u00e0\t\3\2\2\u00df"+
		"\u00de\3\2\2\2\u00e0\u00e3\3\2\2\2\u00e1\u00df\3\2\2\2\u00e1\u00e2\3\2"+
		"\2\2\u00e2\u00e4\3\2\2\2\u00e3\u00e1\3\2\2\2\u00e4\u00e5\7}\2\2\u00e5"+
		"\23\3\2\2\2\u00e6\u00e7\7k\2\2\u00e7\u00e8\7o\2\2\u00e8\u00e9\7r\2\2\u00e9"+
		"\u00ea\7q\2\2\u00ea\u00eb\7t\2\2\u00eb\u00ec\7v\2\2\u00ec\25\3\2\2\2\u00ed"+
		"\u00ee\7h\2\2\u00ee\u00ef\7t\2\2\u00ef\u00f0\7c\2\2\u00f0\u00f1\7i\2\2"+
		"\u00f1\u00f2\7o\2\2\u00f2\u00f3\7g\2\2\u00f3\u00f4\7p\2\2\u00f4\u00f5"+
		"\7v\2\2\u00f5\27\3\2\2\2\u00f6\u00f7\7n\2\2\u00f7\u00f8\7g\2\2\u00f8\u00f9"+
		"\7z\2\2\u00f9\u00fa\7g\2\2\u00fa\u00fb\7t\2\2\u00fb\31\3\2\2\2\u00fc\u00fd"+
		"\7r\2\2\u00fd\u00fe\7c\2\2\u00fe\u00ff\7t\2\2\u00ff\u0100\7u\2\2\u0100"+
		"\u0101\7g\2\2\u0101\u0102\7t\2\2\u0102\33\3\2\2\2\u0103\u0104\7i\2\2\u0104"+
		"\u0105\7t\2\2\u0105\u0106\7c\2\2\u0106\u0107\7o\2\2\u0107\u0108\7o\2\2"+
		"\u0108\u0109\7c\2\2\u0109\u010a\7t\2\2\u010a\35\3\2\2\2\u010b\u010c\7"+
		"r\2\2\u010c\u010d\7t\2\2\u010d\u010e\7q\2\2\u010e\u010f\7v\2\2\u010f\u0110"+
		"\7g\2\2\u0110\u0111\7e\2\2\u0111\u0112\7v\2\2\u0112\u0113\7g\2\2\u0113"+
		"\u0114\7f\2\2\u0114\37\3\2\2\2\u0115\u0116\7r\2\2\u0116\u0117\7w\2\2\u0117"+
		"\u0118\7d\2\2\u0118\u0119\7n\2\2\u0119\u011a\7k\2\2\u011a\u011b\7e\2\2"+
		"\u011b!\3\2\2\2\u011c\u011d\7r\2\2\u011d\u011e\7t\2\2\u011e\u011f\7k\2"+
		"\2\u011f\u0120\7x\2\2\u0120\u0121\7c\2\2\u0121\u0122\7v\2\2\u0122\u0123"+
		"\7g\2\2\u0123#\3\2\2\2\u0124\u0125\7t\2\2\u0125\u0126\7g\2\2\u0126\u0127"+
		"\7v\2\2\u0127\u0128\7w\2\2\u0128\u0129\7t\2\2\u0129\u012a\7p\2\2\u012a"+
		"\u012b\7u\2\2\u012b%\3\2\2\2\u012c\u012d\7n\2\2\u012d\u012e\7q\2\2\u012e"+
		"\u012f\7e\2\2\u012f\u0130\7c\2\2\u0130\u0131\7n\2\2\u0131\u0132\7u\2\2"+
		"\u0132\'\3\2\2\2\u0133\u0134\7v\2\2\u0134\u0135\7j\2\2\u0135\u0136\7t"+
		"\2\2\u0136\u0137\7q\2\2\u0137\u0138\7y\2\2\u0138\u0139\7u\2\2\u0139)\3"+
		"\2\2\2\u013a\u013b\7e\2\2\u013b\u013c\7c\2\2\u013c\u013d\7v\2\2\u013d"+
		"\u013e\7e\2\2\u013e\u013f\7j\2\2\u013f+\3\2\2\2\u0140\u0141\7h\2\2\u0141"+
		"\u0142\7k\2\2\u0142\u0143\7p\2\2\u0143\u0144\7c\2\2\u0144\u0145\7n\2\2"+
		"\u0145\u0146\7n\2\2\u0146\u0147\7{\2\2\u0147-\3\2\2\2\u0148\u0149\7o\2"+
		"\2\u0149\u014a\7q\2\2\u014a\u014b\7f\2\2\u014b\u014c\7g\2\2\u014c/\3\2"+
		"\2\2\u014d\u014e\7<\2\2\u014e\61\3\2\2\2\u014f\u0150\7<\2\2\u0150\u0151"+
		"\7<\2\2\u0151\63\3\2\2\2\u0152\u0153\7.\2\2\u0153\65\3\2\2\2\u0154\u0155"+
		"\7=\2\2\u0155\67\3\2\2\2\u0156\u0157\7*\2\2\u01579\3\2\2\2\u0158\u0159"+
		"\7+\2\2\u0159;\3\2\2\2\u015a\u015b\7/\2\2\u015b\u015c\7@\2\2\u015c=\3"+
		"\2\2\2\u015d\u015e\7>\2\2\u015e?\3\2\2\2\u015f\u0160\7@\2\2\u0160A\3\2"+
		"\2\2\u0161\u0162\7?\2\2\u0162C\3\2\2\2\u0163\u0164\7A\2\2\u0164E\3\2\2"+
		"\2\u0165\u0166\7,\2\2\u0166G\3\2\2\2\u0167\u0168\7-\2\2\u0168I\3\2\2\2"+
		"\u0169\u016a\7-\2\2\u016a\u016b\7?\2\2\u016bK\3\2\2\2\u016c\u016d\7~\2"+
		"\2\u016dM\3\2\2\2\u016e\u016f\7&\2\2\u016fO\3\2\2\2\u0170\u0171\7\60\2"+
		"\2\u0171Q\3\2\2\2\u0172\u0173\7\60\2\2\u0173\u0174\7\60\2\2\u0174S\3\2"+
		"\2\2\u0175\u0176\7B\2\2\u0176U\3\2\2\2\u0177\u0178\7%\2\2\u0178W\3\2\2"+
		"\2\u0179\u017a\7\u0080\2\2\u017aY\3\2\2\2\u017b\u017c\7\177\2\2\u017c"+
		"[\3\2\2\2\u017d\u0181\5`/\2\u017e\u0180\5^.\2\u017f\u017e\3\2\2\2\u0180"+
		"\u0183\3\2\2\2\u0181\u017f\3\2\2\2\u0181\u0182\3\2\2\2\u0182]\3\2\2\2"+
		"\u0183\u0181\3\2\2\2\u0184\u0187\5`/\2\u0185\u0187\t\4\2\2\u0186\u0184"+
		"\3\2\2\2\u0186\u0185\3\2\2\2\u0187_\3\2\2\2\u0188\u0189\t\5\2\2\u0189"+
		"a\3\2\2\2\u018a\u018c\t\6\2\2\u018b\u018a\3\2\2\2\u018c\u018d\3\2\2\2"+
		"\u018d\u018b\3\2\2\2\u018d\u018e\3\2\2\2\u018ec\3\2\2\2\u018f\u0194\7"+
		")\2\2\u0190\u0193\5h\63\2\u0191\u0193\n\7\2\2\u0192\u0190\3\2\2\2\u0192"+
		"\u0191\3\2\2\2\u0193\u0196\3\2\2\2\u0194\u0192\3\2\2\2\u0194\u0195\3\2"+
		"\2\2\u0195\u0197\3\2\2\2\u0196\u0194\3\2\2\2\u0197\u0198\7)\2\2\u0198"+
		"e\3\2\2\2\u0199\u019e\7)\2\2\u019a\u019d\5h\63\2\u019b\u019d\n\7\2\2\u019c"+
		"\u019a\3\2\2\2\u019c\u019b\3\2\2\2\u019d\u01a0\3\2\2\2\u019e\u019c\3\2"+
		"\2\2\u019e\u019f\3\2\2\2\u019fg\3\2\2\2\u01a0\u019e\3\2\2\2\u01a1\u01a6"+
		"\7^\2\2\u01a2\u01a7\t\b\2\2\u01a3\u01a7\5j\64\2\u01a4\u01a7\13\2\2\2\u01a5"+
		"\u01a7\7\2\2\3\u01a6\u01a2\3\2\2\2\u01a6\u01a3\3\2\2\2\u01a6\u01a4\3\2"+
		"\2\2\u01a6\u01a5\3\2\2\2\u01a7i\3\2\2\2\u01a8\u01b3\7w\2\2\u01a9\u01b1"+
		"\5l\65\2\u01aa\u01af\5l\65\2\u01ab\u01ad\5l\65\2\u01ac\u01ae\5l\65\2\u01ad"+
		"\u01ac\3\2\2\2\u01ad\u01ae\3\2\2\2\u01ae\u01b0\3\2\2\2\u01af\u01ab\3\2"+
		"\2\2\u01af\u01b0\3\2\2\2\u01b0\u01b2\3\2\2\2\u01b1\u01aa\3\2\2\2\u01b1"+
		"\u01b2\3\2\2\2\u01b2\u01b4\3\2\2\2\u01b3\u01a9\3\2\2\2\u01b3\u01b4\3\2"+
		"\2\2\u01b4k\3\2\2\2\u01b5\u01b6\t\t\2\2\u01b6m\3\2\2\2\u01b7\u01b9\t\3"+
		"\2\2\u01b8\u01b7\3\2\2\2\u01b9\u01ba\3\2\2\2\u01ba\u01b8\3\2\2\2\u01ba"+
		"\u01bb\3\2\2\2\u01bb\u01bc\3\2\2\2\u01bc\u01bd\b\66\7\2\u01bdo\3\2\2\2"+
		"\u01be\u01bf\13\2\2\2\u01bf\u01c0\3\2\2\2\u01c0\u01c1\b\67\b\2\u01c1q"+
		"\3\2\2\2\u01c2\u01c3\7]\2\2\u01c3\u01c4\3\2\2\2\u01c4\u01c5\b8\t\2\u01c5"+
		"s\3\2\2\2\u01c6\u01c7\7^\2\2\u01c7\u01c8\13\2\2\2\u01c8\u01c9\3\2\2\2"+
		"\u01c9\u01ca\b9\n\2\u01cau\3\2\2\2\u01cb\u01d1\7$\2\2\u01cc\u01cd\7^\2"+
		"\2\u01cd\u01d0\13\2\2\2\u01ce\u01d0\n\n\2\2\u01cf\u01cc\3\2\2\2\u01cf"+
		"\u01ce\3\2\2\2\u01d0\u01d3\3\2\2\2\u01d1\u01cf\3\2\2\2\u01d1\u01d2\3\2"+
		"\2\2\u01d2\u01d4\3\2\2\2\u01d3\u01d1\3\2\2\2\u01d4\u01d5\7$\2\2\u01d5"+
		"\u01d6\3\2\2\2\u01d6\u01d7\b:\13\2\u01d7w\3\2\2\2\u01d8\u01d9\7$\2\2\u01d9"+
		"\u01da\7^\2\2\u01da\u01de\13\2\2\2\u01db\u01dc\n\n\2\2\u01dc\u01de\7$"+
		"\2\2\u01dd\u01d8\3\2\2\2\u01dd\u01db\3\2\2\2\u01de\u01df\3\2\2\2\u01df"+
		"\u01e0\b;\f\2\u01e0y\3\2\2\2\u01e1\u01e2\7_\2\2\u01e2\u01e3\3\2\2\2\u01e3"+
		"\u01e4\b<\r\2\u01e4{\3\2\2\2\u01e5\u01e6\7\2\2\3\u01e6\u01e7\3\2\2\2\u01e7"+
		"\u01e8\b=\16\2\u01e8}\3\2\2\2\u01e9\u01ea\13\2\2\2\u01ea\u01eb\3\2\2\2"+
		"\u01eb\u01ec\b>\17\2\u01ec\177\3\2\2\2\u01ed\u01ee\7}\2\2\u01ee\u01ef"+
		"\3\2\2\2\u01ef\u01f0\b?\20\2\u01f0\u0081\3\2\2\2\u01f1\u01f2\7^\2\2\u01f2"+
		"\u01f3\13\2\2\2\u01f3\u01f4\3\2\2\2\u01f4\u01f5\b@\21\2\u01f5\u0083\3"+
		"\2\2\2\u01f6\u01fc\7$\2\2\u01f7\u01f8\7^\2\2\u01f8\u01fb\13\2\2\2\u01f9"+
		"\u01fb\n\n\2\2\u01fa\u01f7\3\2\2\2\u01fa\u01f9\3\2\2\2\u01fb\u01fe\3\2"+
		"\2\2\u01fc\u01fa\3\2\2\2\u01fc\u01fd\3\2\2\2\u01fd\u01ff\3\2\2\2\u01fe"+
		"\u01fc\3\2\2\2\u01ff\u0200\7$\2\2\u0200\u0201\3\2\2\2\u0201\u0202\bA\22"+
		"\2\u0202\u0085\3\2\2\2\u0203\u0204\7$\2\2\u0204\u0205\7^\2\2\u0205\u0209"+
		"\13\2\2\2\u0206\u0207\n\n\2\2\u0207\u0209\7$\2\2\u0208\u0203\3\2\2\2\u0208"+
		"\u0206\3\2\2\2\u0209\u020a\3\2\2\2\u020a\u020b\bB\23\2\u020b\u0087\3\2"+
		"\2\2\u020c\u020f\5\b\3\2\u020d\u020f\5\n\4\2\u020e\u020c\3\2\2\2\u020e"+
		"\u020d\3\2\2\2\u020f\u0210\3\2\2\2\u0210\u0211\bC\24\2\u0211\u0089\3\2"+
		"\2\2\u0212\u0213\7\177\2\2\u0213\u0214\bD\3\2\u0214\u008b\3\2\2\2\u0215"+
		"\u0216\7\2\2\3\u0216\u0217\3\2\2\2\u0217\u0218\bE\25\2\u0218\u008d\3\2"+
		"\2\2\u0219\u021a\13\2\2\2\u021a\u021b\3\2\2\2\u021b\u021c\bF\26\2\u021c"+
		"\u008f\3\2\2\2\u021d\u0221\n\13\2\2\u021e\u021f\7^\2\2\u021f\u0221\13"+
		"\2\2\2\u0220\u021d\3\2\2\2\u0220\u021e\3\2\2\2\u0221\u0222\3\2\2\2\u0222"+
		"\u0220\3\2\2\2\u0222\u0223\3\2\2\2\u0223\u0224\3\2\2\2\u0224\u0225\bG"+
		"\27\2\u0225\u0091\3\2\2\2\u0226\u0227\7_\2\2\u0227\u0228\3\2\2\2\u0228"+
		"\u0229\bH\30\2\u0229\u0093\3\2\2\2\u022a\u022b\7\2\2\3\u022b\u022c\3\2"+
		"\2\2\u022c\u022d\bI\31\2\u022d\u0095\3\2\2\2#\2\3\4\5\u009d\u00a3\u00ab"+
		"\u00b1\u00bb\u00d2\u00e1\u0181\u0186\u018d\u0192\u0194\u019c\u019e\u01a6"+
		"\u01ad\u01af\u01b1\u01b3\u01ba\u01cf\u01d1\u01dd\u01fa\u01fc\u0208\u020e"+
		"\u0220\u0222";
	public static final ATN _ATN =
		ATNSimulator.deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}