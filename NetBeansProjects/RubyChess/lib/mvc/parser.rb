require 'mvc/arrange_command'

class Parser

  ARRANGE_EXPR = /^arrange$/
  MOVE_EXPR = /^([prnbqk])([a-h])([1-8])(x?)([a-h])([1-8])$/
  EXIT_EXPR = /^exit$/

  attr_accessor :factory, :chess_factory
  
  def parse(str)

    # Normalise to lower case
    original_str = str
    str.strip!
    str.downcase!

    # Match against known commands
    arrange_match = ARRANGE_EXPR.match(str)
    move_match = MOVE_EXPR.match(str)
    exit_match = EXIT_EXPR.match(str)

    # Process if move command match
    if (arrange_match)
      return ArrangeCommand.new
    elsif (move_match)
      piece_type = nil
      piece_type = Chess::Pawn if (move_match.captures[0] == "p")
      piece_type = Chess::Rook if (move_match.captures[0] == "r")
      piece_type = Chess::Knight if (move_match.captures[0] == "n")
      piece_type = Chess::Bishop if (move_match.captures[0] == "b")
      piece_type = Chess::Queen if (move_match.captures[0] == "q")
      piece_type = Chess::King if (move_match.captures[0] == "k")

      from_file = "file_#{move_match.captures[1]}".to_sym
      from_rank = "rank_#{move_match.captures[2]}".to_sym

      capture = false
      if (move_match.captures[3] == "x")
        capture = true
      end

      to_file = "file_#{move_match.captures[4]}".to_sym
      to_rank = "rank_#{move_match.captures[5]}".to_sym

      move = chess_factory.new_move(piece_type, from_file, from_rank, to_file, to_rank, capture)
      move_cmd = factory.new_move_command(move)
      return move_cmd
    end

    if (exit_match)
      return factory.new_exit_command
    end

    return factory.new_non_command("Could not parse command <#{original_str}>.")
  end
end
