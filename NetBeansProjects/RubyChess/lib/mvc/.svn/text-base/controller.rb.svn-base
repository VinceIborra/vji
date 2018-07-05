# To change this template, choose Tools | Templates
# and open the template in the editor.

class Controller

  attr_accessor :board, :message


  def process_command(command)
    self.message = ""
    begin
      self.send("process_#{underscore(command.class.to_s)}", command)
    rescue Exception => exception
      self.message = exception.message
    end
  end
  
  def process_arrange_command(arrange_command)
    board.arrange_pieces
  end

  def process_move_command(move_command)
    board.move_piece(move_command.move)
  end

  def process_non_command(non_command)
    self.message = non_command.message
  end

  # Copied from the "Ruby on Rails" code base
  def underscore(camel_cased_word)
     camel_cased_word.to_s.gsub(/::/, '/').
       gsub(/([A-Z]+)([A-Z][a-z])/,'\1_\2').
       gsub(/([a-z\d])([A-Z])/,'\1_\2').
       tr("-", "_").
       downcase
  end

end
