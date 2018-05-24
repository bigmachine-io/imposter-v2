var AsciiTable = require('ascii-table')

const and = (x,y) => x && y ? 1 : 0;
const or = (x,y) => x || y ? 1 : 0;
const not = x => x ? 0 : 1;

//secondary
const xor = (x,y) => x !== y ? 1 : 0;
const equiv = (x,y) => x === y ? 1 : 0;
const imp = (x,y) => x===1 ? y : 1;

//complementatary
const identity = (x,y) => not(not(x));
const nand = (x,y) => not(and(x,y));
const nor = (x,y) => not(or(x,y));

//complementary secondary
const xnor = (x,y) => not(xor(x,y));
const nequiv = (x,y) => not(equiv(x,y));
const nimp = (x,y) => !x ? y : 1;


const halfAdder = (x,y) => [and(x,y), xor(x,y)];
console.log(halfAdder(1,1)); //should be [1,0]

//first try
const fullAdder1 = function(x, y, c = 0){
  //send the first two inputs to the half adder
  //this is simple 2-bit addition
  const firstStep = halfAdder(x,y);
  //send the left result back into the half adder with the carry bit
  const secondStep = halfAdder(firstStep[1],c);
  //finally, OR the result of the firstStep, left side (0)
  //with the left of the secondStep
  const leftResult = or(firstStep[0], secondStep[0]);
  const rightResult = secondStep[1];
  //return the results
  return [leftResult, rightResult]
};

//second try
const fullAdder2 = function(x, y, c = 0){
  if(c===0){
    return halfAdder(x,y);
  }else{
    left = or(x,y);
    right = equiv(x,y);
    return [left,right]
  }
}

//third try
const fullAdder = (x,y,c = 0) => c ? [or(x,y), equiv(x,y)] : halfAdder(x,y);

console.log(fullAdder(1,1,1))

let tbl = new AsciiTable("Full Adder")
tbl
  .addRow(0, 0, 0, fullAdder(0,0,0))
  .addRow(0, 0, 1, fullAdder(0, 0, 1))
  .addRow(0, 1, 0, fullAdder(0, 1, 0))
  .addRow(0, 1, 1, fullAdder(0, 1, 1))
  .addRow(1, 0, 0, fullAdder(1, 0, 0))
  .addRow(1, 0, 1, fullAdder(1, 0, 1))
  .addRow(1, 1, 0, fullAdder(1, 1, 0))
  .addRow(1, 1, 1, fullAdder(1, 1, 1))

console.log(tbl.toString())  
