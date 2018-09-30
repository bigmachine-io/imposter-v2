const crypto = require('crypto');
//we could build on the fly but this is a bit more performant and
//that matters a lot. Build it up when the module loads

let lastKey = 0;
let zero = "0";
const difficultyBlocks = [zero];
for(i = 1; i<18;i++){
  zero += "0";
  difficultyBlocks.push(zero);
}
class BlockChain{
  constructor(){
    this.blocks = {};
    this.head = null;
  }
  createBlock(txs, timestamp){
    const block = new Block(txs,timestamp)
    block.mine(3);
    this.blocks[block.key] = block;
    this.lastBlock = this.head = block; //the end of the list
  }
  traverse(fn){
    while(this.head){
      fn(this.head);
      //move the head back one
      this.head = this.blocks[this.head.previous];
    }
    //put the head back
    this.head = this.lastBlock;
  }
}

class Block{
  constructor(transactions, timestamp){
    if(!transactions) throw new Error("Need to have transaction data");
    if(!timestamp) throw new Error("Set the timestamp please to UTC for this transaction");
    this.transactions = transactions;
    //validate transaction set...
    this.timestamp = timestamp;
    this.key = null; //we'll calculate this in generate_key
    this.previous = lastKey;
    this.nonce = 0; //start at 0
    this.hashVal = this.transactions  + this.previous + this.timestamp;
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
      let possibleHash = crypto.createHash('sha256').update(this.hashVal + this.nonce).digest('base64');
      //did we find it?
      mined = possibleHash.substring(0,difficulty) === lookingFor;

      if(!mined) {
        this.nonce+=1;
      }else {
        const end = new Date().getTime();
        const elapsed = (end - start)/1000;
        this.key = possibleHash;
        lastKey = this.key;
        console.log(`Found it: ${possibleHash}! \nThe nonce is ${this.nonce}. It took exactly ${elapsed} seconds`);
      }
    }
    while(!mined);
  }
  isValid(){
    return this.key === crypto.createHash('sha256').update(this.hashVal + this.nonce).digest('base64');
  }
}
const txs1 = [
  {from: "me", to: "you", amount: 12.00},
  {from: "you", to: "me", amount: 5.00}
];

const txs2 = [
  {from: "me", to: "you", amount: 5.00},
  {from: "you", to: "me", amount: 12.00}
];

const chain = new BlockChain();
chain.createBlock(txs1,1538253519);
chain.createBlock(txs2,1538253545);

chain.traverse((block) => {
  console.log(block.key)
});