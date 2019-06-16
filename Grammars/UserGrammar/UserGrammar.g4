grammar UserGrammar;

rul: 'Si' condicion;

 condicion: condicion connector condicion
    | numericAttribute comparisionNumeric INT
    | booleanAttribute
    | 'no' booleanAttribute
    ;

booleanAttribute: 'es vegetariano'
    | 'está ingresado'
    ;

numericAttribute: 'la edad del usuario';

comparisionNumeric: 'es mayor que';

connector: ' y '
    | ' o '
    ;

INT : DIGIT+ ; // references the DIGIT helper rule
fragment DIGIT : [0-9] ; // Not a token by itself