//These are simple remainder operations in ES8
//When both divisor(12) and dividend (6+13.3)
//are positive, the result is positive
const x = (6 + 13.3) % 12;
console.log(x);

//when the dividend (6 + 13.3) is negative, the result is negative
//this is the main difference with the modulus operation
const y = -(6 + 13.3) % 12;
console.log(y);

//with the modulus operation, the *divisor* (12) dictates the 
//sign, which it does not here
const z = (6 + 13.3) % -12;
console.log(z);

//with the modulus operation, the *divisor* (12) dictates the 
//sign, which it does not here
const zz = -(6 + 13.3) % -12;
console.log(zz);


//this is a "true" modulus function. It divides by 12, making
//sure the answer is negative
const mod = (x, y) => (x % y + y) % y
const a = mod((6 + 13.3),-12)
console.log(a)
