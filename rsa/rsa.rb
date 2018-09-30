p= 821
q= 1303
N = p * q
e = 3
M = 128540
C = (M ** e) % N

X = (p-1)*(q-1)
p X
d = (1 % X)/e
p d
puts "Cipher text is #{C}"
