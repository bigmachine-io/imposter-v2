const add =function(x,y) {
  // Iterate till there is no carry
  let carry_bit = 0;
  do{
    //using a bitwise AND will tell us
    //if there is a carry bit somewhere
    carry_bit = x & y;

    //This is the XOR addition, which is our sum
    x = x ^ y;

    // If we have a carry bit, reset y
    // to the shifted value
    //if carry is 0, this will be 0
    y = carry_bit << 1;
  } while(carry_bit)
  return x;
}
console.log(add(49,93));

//obligatory recursive one-liner
const addX = (x,y) => y === 0  ? x : addX((x ^ y), (x & y) << 1);
console.log(addX(49,93));
