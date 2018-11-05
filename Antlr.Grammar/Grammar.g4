// TODO: Divide the grammar in lexer and parser.

grammar Grammar;

/*
 * Parser Rules => ÁRBOL
 */

 regla: 'Si' condicion;

 condicion: condicion connector condicion
			| attributeString comparisonString SEARCH
			| attributeNumeric comparsionNumeric INT
			| attributeBoolean
			| 'no' attributeBoolean

			;

/*
 * Lexer Rules => EXPRESIONES REGULARES
 */

attributeNumeric : 'la presion arterial del usuario'
					| 'la edad del usuario'
					;

attributeString : 'el nombre del usuario'
					| 'la dirección del usuario'
					;

attributeBoolean : 'es vegetariano'
					| 'duerme solo'
					;

connector : ' y '
			| ' o '
			;

comparsionNumeric : 'es mayor que'
					| 'es igual a'
					| 'es menor que'
					;

comparisonString : 'contiene'
					| 'empieza por'
					| 'termina en'
					;

INT : DIGIT+ ; // references the DIGIT helper rule
fragment DIGIT : [0-9] ; // Not a token by itself

SEARCH: '#' STRING '#';
fragment STRING : [a-zA-Z]+;

WS : [ \t\n\r]+ -> skip ; // Toss out whitespace