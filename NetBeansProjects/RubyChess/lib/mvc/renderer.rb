# To change this template, choose Tools | Templates
# and open the template in the editor.

class Renderer

  def intro
"
Commands:

  Move A Piece:
    <piece><from_file><from_rank>[<capture>]<to_file><to_rank>

    piece   - p,r,n,b,q,k
    file    - a,b,c,d,e,f,g,h
    rank    - 1,2,3,4,5,6,7,8
    capture - x

  Other:
    exit - to exit
"
  end

  def prompt
    "> "
  end

  def render(board)
    str = "\n"
    str = str + "     A   B   C   D   E   F   G   H\n"
    str = str + "   +---+---+---+---+---+---+---+---+\n"
    Chess::Rank.values.reverse.each do |rank|
      str = str + rank.to_s.demodulized[5,1] + "  |"
      Chess::File.values.each do |file|
        square = board.square_at(file, rank)
        if (square.shade == Chess::Shade::Light)
          str = str + " "
        else
          str = str + "-"
        end
        piece = square.piece
        if (piece.nil?)
            piece_str = "-" if square.shade == Chess::Shade::Dark
            piece_str = " " if square.shade == Chess::Shade::Light
        elsif (piece.kind_of?(Chess::Rook))
            piece_str = "R" if piece.colour == Chess::Colour::Black
            piece_str = "r" if piece.colour == Chess::Colour::White
        elsif (piece.kind_of?(Chess::Knight))
            piece_str = "N" if piece.colour == Chess::Colour::Black
            piece_str = "n" if piece.colour == Chess::Colour::White
        elsif (piece.kind_of?(Chess::Bishop))
            piece_str = "B" if piece.colour == Chess::Colour::Black
            piece_str = "b" if piece.colour == Chess::Colour::White
        elsif (piece.kind_of?(Chess::Queen))
            piece_str = "Q" if piece.colour == Chess::Colour::Black
            piece_str = "q" if piece.colour == Chess::Colour::White
        elsif (piece.kind_of?(Chess::King))
            piece_str = "K" if piece.colour == Chess::Colour::Black
            piece_str = "k" if piece.colour == Chess::Colour::White
        elsif (piece.kind_of?(Chess::Pawn))
            piece_str = "P" if piece.colour == Chess::Colour::Black
            piece_str = "p" if piece.colour == Chess::Colour::White
        end
        str = str + piece_str
        if (square.shade == Chess::Shade::Light)
          str = str + " |"
        else
          str = str + "-|"
        end
      end
      str = str + "\n";
      str = str + "   +---+---+---+---+---+---+---+---+\n"
    end
    return str
  end
#"
#     A   B   C   D   E   F   G   H
#   +---+---+---+---+---+---+---+---+
#8  |   |---|   |---|   |---|   |---|
#   +---+---+---+---+---+---+---+---+
#7  |---|   |---|   |---|   |---|   |
#   +---+---+---+---+---+---+---+---+
#6  |   |---|   |---|   |---|   |---|
#   +---+---+---+---+---+---+---+---+
#5  |---|   |---|   |---|   |---|   |
#   +---+---+---+---+---+---+---+---+
#4  |   |---|   |---|   |---|   |---|
#   +---+---+---+---+---+---+---+---+
#3  |---|   |---|   |---|   |---|   |
#   +---+---+---+---+---+---+---+---+
#2  |   |---|   |---|   |---|   |---|
#   +---+---+---+---+---+---+---+---+
#1  |---|   |---|   |---|   |---|   |
#   +---+---+---+---+---+---+---+---+
#"

end
