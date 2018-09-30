var AsciiTable = require('ascii-table')
const ha = (x,y) => [(x & y),(x ^ y)];
const fa = (x,y,c = 0) => c ? [(x | y), (x === y ? 1 : 0)] : ha(x,y);

let tbl = new AsciiTable("Full Adder")
tbl
  .addRow(0, 0, 0, fa(0,0,0))
  .addRow(0, 0, 1, fa(0, 0, 1))
  .addRow(0, 1, 0, fa(0, 1, 0))
  .addRow(0, 1, 1, fa(0, 1, 1))
  .addRow(1, 0, 0, fa(1, 0, 0))
  .addRow(1, 0, 1, fa(1, 0, 1))
  .addRow(1, 1, 0, fa(1, 1, 0))
  .addRow(1, 1, 1, fa(1, 1, 1))

console.log(tbl.toString())
