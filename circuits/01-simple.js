var AsciiTable = require('ascii-table')

//primary
const and = (x,y) => x && y ? 1 : 0;
const or = (x,y) => x || y ? 1 : 0;
const not = x => x ? 0 : 1;

//secondary
const xor = (x,y) => x !== y ? 1 : 0;
const equiv = (x,y) => x === y ? 1 : 0;
const imp = (x,y) => x ? y : 1;

//complementatary
const identity = (x,y) => not(not(x));
const nand = (x,y) => not(and(x,y));
const nor = (x,y) => not(or(x,y));

//complementary secondary
const xnor = (x,y) => not(xor(x,y));
const nequiv = (x,y) => not(equiv(x,y));
const nimp = (x,y) => !x ? y : 0;


const ascii = (op, fn) => {
  const tbl = new AsciiTable(`${op}`)
  tbl
    //.setHeading('A', 'B', op)
    .addRow(0, 0, fn(0,0))
    .addRow(0, 1, fn(0,1))
    .addRow(1, 0, fn(1,0))
    .addRow(1, 1, fn(1,1))
  console.log(tbl.toString())  
}

//primary
ascii("AND", and);
ascii("OR", or);
ascii("NOT", not);

//secondary
ascii("XOR", xor);
ascii("IMP", imp);
ascii("EQUIV", equiv);

//complementary
ascii("IDENTITY", identity);
ascii("NAND", nand);
ascii("NOR", nor);

//complementary secondary
ascii("XNOR", xnor);
ascii("NEQUIV", nequiv);
ascii("NIMP", nimp);
