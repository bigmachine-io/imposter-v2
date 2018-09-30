class Block{
  constructor(transactions=[], previous=0, timestamp=new Date()){
    this.transactions = transactions;
    //validate transaction set...
    this.timestamp = timestamp;
    this.key = null; //we'll calculate this in generate_key
    this.previous = previous;
    this.nonce = 0; //start at 0
  }
  mine(difficulty){
    //mining this block will generate a key
    //based on some level of difficulty. In our case
    //we need a hash with some number of 0s in front
    //that will be determined by difficulty
  }
  isValid(){
    //assure that the key is the SHA356 of the transactions
  }
}
