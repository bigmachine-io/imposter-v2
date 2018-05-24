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
const fullAdder = (x,y,c = 0) => c ? [or(x,y), equiv(x,y)] : halfAdder(x,y);

const binaryAddition = function(x,y){
  //our output, which is a string
  let sum = "";
  //initialize the carry bit
  let c = 0;
  //handle length differences by padding the start with 0s
  if(x.length > y.length) y = y.padStart(x.length,"0");
  if(y.length > x.length) x = x.padStart(y.length,"0");

  //loop from right to left
  for(let i = x.length -1; i >= 0; i--){
    //pull the numbers off that we need
    //making sure to convert to ints!
    const a = parseInt(x[i]);
    const b = parseInt(y[i]);
    //send to the full adder
    const fa = fullAdder(a,b,c);
    //the carry bit will be in the leftmost position
    //or, the first element of the array
    c = fa[0] === 1 ? 1 : 0;
    //append the rightmost to our sum
    sum = fa[1] + sum;
  }
  //tack on a carry bit if needed
  return c ? c + sum : sum;
}

console.log(binaryAddition('11','11')); //3 + 3 = 6 = 110
console.log(binaryAddition('011','110')); //3 + 3 = 6 = 110
console.log(binaryAddition('11011','1111')); //27 + 15 = 42 = 10101