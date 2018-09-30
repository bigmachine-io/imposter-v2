//for our equation
const base = 544469876321321654565465;
const modulus = 966546546562136846513549546213216549685621321654656549546546546546845654546546666546546546546546543213332131;

//Alice and Bob's secrets
const aliceSecret = 2;
const bobSecret = 4;

const publicKey = (secret) => Math.pow(base,secret) % modulus;
const secretKey = (publicKey, secretKey) =>  Math.pow(publicKey,secretKey) % modulus;


const alicePublicKey = publicKey(aliceSecret);
const bobPublicKey = publicKey(bobSecret);

const aliceEncryptionKey = secretKey(bobPublicKey,aliceSecret);
const bobEncryptionKey = secretKey(alicePublicKey,bobSecret); //7

console.log(alicePublicKey); //7
console.log(bobPublicKey); //4

console.log(aliceEncryptionKey); //7
console.log(bobEncryptionKey); //7