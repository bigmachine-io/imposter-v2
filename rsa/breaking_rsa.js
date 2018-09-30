const sieve = require("./sieve");

const semiprime = 1069763;
const primes = (sieve((semiprime + 1)/2));
console.log(`Starting at ${new Date()}`)
for(let p1 in primes){
  for(let p2 in primes){
    if(p1 * p2 === semiprime){
      console.log(`AHA! Found them: ${p1} and ${p2}`);
      console.log(`Finished at ${new Date()}`)
      return;
    }
  }
}
