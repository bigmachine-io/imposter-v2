class Lovebug
  def initialize()
    @encoding = {
      "0000" => "!",
      "0001" => "G",
      "0100" => "O",
      "1100" => "F",
      "0101" => "M",
      "1101" => "🙄",
      "1110" => "💩",
      "1111" => " "  
    }
    @dictionary = {
      "OMG" => "",
      "OMG!" => "",
      "OMFG" => "",
      "OMFG!" => "",
      "🙄" => "",
      "💩" => "",
      "💩!" => ""
    }
  end
  
  def valid_message_length?(mssg)
    mssg.length % 4 == 0
  end
  
  def valid_code_word?(code_word)
    @encoding.keys.include?(code_word)
  end
  
  def parse_code_words(mssg)
    mssg.scan(/(....)/).flatten
  end

  def best_guess(code_word)
    #get the hamming distance to the "nearest" codeword
    hamming = hamming_distance(code_word)
    #our output variable
    replacement_found = nil
    #the list is already sorted, so loop until a match is found
    #in the dictionary
    hamming.each do |h|
      if(@encoding.has_key?(h[:key])) then 
        #go with the first candidate
        #this will always return as
        #the hamming distance will always 
        #max be at least 4
        return h[:key]
      end
    end
  end

  def correct_errors(code_words)
    code_words.map do |code_word| 
      valid_code_word?(code_word) ? code_word : best_guess(code_word)
    end
  end

  def decode(mssg)
    #split the message into 4 bit chunks
    code_words = parse_code_words(mssg)
    #correct any errors
    corrected = correct_errors(code_words)
    #decode
    corrected.map {|code_word| @encoding[code_word]}.join()
  end

  def hamming_distance(code_word)
    distances = []
    #iterate over our encoding scheme, looking at the binary values
    @encoding.keys.each do |key|
      #initialize a result hash for convenience
      result = {key: key, distance: 0}
      #check each character of the key with the mssg
      key.chars.each_with_index do |c,i| 
        #increment the distance if the characters don't match
        result[:distance] = result[:distance] + 1 unless (code_word[i] == c)
      end
      #append the codeword comparison result
      distances << result
    end
    #sort low to high
    distances.sort {|x,y| x[:distance] <=> y[:distance]}
  end
end

#message with error
mssg= "010001011001"
lovebug = Lovebug.new
p lovebug.decode("010001011001")
p lovebug.decode("010001011011")
#<-- this one here