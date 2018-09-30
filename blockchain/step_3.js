const crypto = require('crypto');
//we could build on the fly but this is a bit more performant and
//that matters a lot. Build it up when the module loads
let zero = "0";
const difficultyBlocks = [zero];
for(i = 1; i<18;i++){
  zero += "0";
  difficultyBlocks.push(zero);
} 
class Block{
  constructor(transactions, previous=0, timestamp){
    if(!transactions) throw new Error("Need to have transaction data");
    if(!timestamp) throw new Error("Set the timestamp please to UTC for this transaction");
    this.transactions = transactions;
    //validate transaction set...
    this.timestamp = timestamp;
    this.key = null; //we'll calculate this in generate_key
    this.previous = previous;
    this.nonce = 0; //start at 0
  }
  mine(difficulty=5){
    //make sure we have some level of effort
    if(difficulty < 2) throw new Error("This isn't much of a challenge");
    if(difficulty > 18) throw new Error("Do polar icecaps matter to you bro?");
    //find the block we're looking for
    let lookingFor = difficultyBlocks[difficulty-1];
    let mined = false;
    //timer
    const start = new Date().getTime();
    do {
      let hashVal = this.transactions + this.nonce + this.previous + this.timestamp ;
      let possibleHash = crypto.createHash('sha256').update(hashVal).digest('base64');
      //did we find it?
      mined = possibleHash.substring(0,difficulty) === lookingFor;

      if(!mined) {
        this.nonce+=1;
      }else {
        const end = new Date().getTime();
        const elapsed = (end - start)/1000;
        console.log(`Found it: ${possibleHash}! \nThe nonce is ${this.nonce}. It took exactly ${elapsed} seconds`)
      }
    }
    while(!mined);
  }
  isValid(){
    //assure that the key is the SHA356 of the transactions
  }
}
const txs = [
  {from: "me", to: "you", amount: 12.00},
  {from: "you", to: "me", amount: 5.00}
]
const block = new Block(txs, 0, 1538253519);
block.mine(2);