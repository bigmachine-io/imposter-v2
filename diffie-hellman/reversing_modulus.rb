def big_one_way
  found = false
  (1..99488377227).each do |n|
    if 321048^n % 99488377227 == 46367344
      puts "Ha! The answer is #{n}"
      found = true
      break
    end
  end
  return found
end
res = big_one_way
puts "DONE"


#super simple to reverse
# (1..1000).each do |n|
#   if n % 12 == 8
#     puts "Ha! The answer is #{n}"
#     break
#   end
# end
