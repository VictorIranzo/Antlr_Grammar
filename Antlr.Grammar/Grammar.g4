// TODO: Divide the grammar in lexer and parser.

grammar Grammar;

/*
 * Parser Rules => ÁRBOL
 */

 regla: 'Si' condicion;

 condicion: condicion UNION condicion
			| ATTRIBUTESTRING CONTAINS SEARCH
			| ATTRIBUTENUMERIC GREATERTHAN INT
			;

/*
 * Lexer Rules => EXPRESIONES REGULARES
 */

ATTRIBUTENUMERIC : 'la presión arterial del usuario';
ATTRIBUTESTRING : 'el nombre del usuario';

UNION : ' y ';

GREATERTHAN : 'es mayor que';
CONTAINS : 'contiene';

INT : DIGIT+ ; // references the DIGIT helper rule
fragment DIGIT : [0-9] ; // Not a token by itself

SEARCH: '"' STRING '"';
fragment STRING : [a-zA-Z]+;

WS : [ \t\n\r]+ -> skip ; // Toss out whitespace