var AsciiTable = require('ascii-table')

const and = (x,y) => x && y ? 1 : 0;
const or = (x,y) => x || y ? 1 : 0;
const xor = (x,y) => x ^ y ? 1 : 0;
const xnor = (x,y) => !(x ^ y) ? 1 : 0;

const nand = (x,y) => !(x && y) ? 1 : 0;
const nor = (x,y) => !(x || y) ? 1 : 0;

const halfAdder = function(x, y){
  const right = xor(x,y);
  const left = and(x,y);
  return [left, right]
};

const fullAdder = function(x, y, c = 0){
  if(c===0){
    return halfAdder(x,y);
  }else{
    left = or(x,y);
    right = xnor(x,y);
    return [left,right]
  }
}

const binaryAddition = function(x,y){
  let sum = "";
  let c = 0;
  //handle length differences by padding the start with 0s
  if(x.length > y.length) y = y.padStart(x.length,"0");
  if(y.length > x.length) x = x.padStart(y.length,"0");

  for(let i = x.length -1; i >= 0; i--){
    const a = parseInt(x[i]);
    const b = parseInt(y[i]);
    const fa = fullAdder(a,b,c);
    c = fa[0];
    sum = fa[1] + sum;
  }
  //tack on a carry bit if needed
  return c ? c + sum : sum;
}

const binaryMultiplication = function(x,y){
  //These are the numbers that we produce 
  //during the multiplication steps
  const nums = [];
  //This will be our homegrown bitshifter
  //which will add a 0 to x for every iteration
  //in the same way you add a zero for 10s, 100s, etc
  let zeroPad = 0;
  //loop right to left
  for(let i = y.length-1; i >= 0; i--){
    //get the current number we're multiplying by
    const thisY = parseInt(y[i]);
    //if it's one...
    if(thisY===1){
      //add a 0 to the end
      const thisX = x.padEnd(x.length + zeroPad,"0"); //bitshift to the left
      //remember it
      nums.push(thisX);
    }
    //increment the 0 pad
    zeroPad++;
  }
  //set the sum to the initial number
  let sum = nums[0];
  //loop the remaining numbers
  for(let i = 1; i <= nums.length-1;i++){
    //increment the sum by using addition
    sum = binaryAddition(sum,nums[i]);
  }
  return sum;
}
console.log(binaryMultiplication('11','11')); //1001
