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
  end
  
  def valid_message_length?(mssg)
    mssg.length % 4 == 0
  end
  
  def valid_code_words?(mssg)
    parse_message(mssg) do |code_word|
      return false unless @encoding.keys.include?(code_word)
    end
    true
  end
  
  def parse_message(mssg)
    mssg.scan(/(....)/) do |code_word|
      yield code_word[0]
    end
  end

  def decode(mssg)
    raise "Invalid message received" unless valid_message_length?(mssg)
    raise "Invalid codewords present" unless valid_code_words?(mssg)
    out = []
    parse_message(mssg) do |code_word|
      out << @encoding[code_word]
    end
    out.join()
  end
end

mssg= "010001010001"
lovebug = Lovebug.new()
p lovebug.decode(mssg)
