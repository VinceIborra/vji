require 'chess/shade'
require 'chess/square'
require 'chess/assertions'
require 'chess/move'

module Chess
  class Board

    include Chess::Assertions

    attr_accessor :factory, :tracker

    def initialize
      @squares_hash = {}
    end

    def setup
      first_shade = Shade::Light
      Rank.values.reverse.each do |rank|
        shade = first_shade
        @squares_hash[rank] = {}
        File.values.each do |file|
          @squares_hash[rank][file] = self.factory.new_square(file, rank, shade)
          if (shade == Shade::Light)
            shade = Shade::Dark
          else
            shade = Shade::Light
          end
        end
        if (first_shade == Shade::Light)
          first_shade = Shade::Dark
        else
          first_shade = Shade::Light
        end
      end
    end
    def squares
      squares = []
      Rank.values.reverse.each do |rank|
        File.values.each do |file|
          square = self.square_at(file, rank)
          squares << square if !square.nil?
        end
      end
      return squares
    end
    def square_at(file, rank)
      assert_valid_file(file)
      assert_valid_rank(rank)
      if (@squares_hash[rank].nil?)
        return nil
      end
      return @squares_hash[rank][file]
    end

    def pieces
      pieces = []
      Rank.values.reverse.each do |rank|
        File.values.each do |file|
          piece = self.piece_at(file, rank)
          pieces << piece if !piece.nil?
        end
      end
      return pieces
    end
    def place_piece(piece, file, rank)
      assert_not_nil(piece, "<nil> is not a valid piece value.")
      assert_valid_file(file)
      assert_valid_rank(rank)
      square = self.square_at(file, rank)
      assert_nil(square.piece, "A piece is already using #{file}:#{rank}.")
      square.piece = piece
      tracker.track(piece, factory.new_placement(file, rank))
    end
    def remove_piece(file, rank)
      assert_valid_file(file)
      assert_valid_rank(rank)
      square = self.square_at(file, rank)
      if (!square.nil?)
        square.piece = nil
      end
    end
    def piece_at(file, rank)
      assert_valid_file(file)
      assert_valid_rank(rank)
      return self.square_at(file, rank).piece
    end

    def arrange_pieces

      self.clear_pieces

      rank = Rank::Rank_8
      colour = Colour::Black
      self.place_piece(factory.new_rook(colour),   File::File_a, rank)
      self.place_piece(factory.new_knight(colour), File::File_b, rank)
      self.place_piece(factory.new_bishop(colour), File::File_c, rank)
      self.place_piece(factory.new_queen(colour),  File::File_d, rank)
      self.place_piece(factory.new_king(colour),   File::File_e, rank)
      self.place_piece(factory.new_bishop(colour), File::File_f, rank)
      self.place_piece(factory.new_knight(colour), File::File_g, rank)
      self.place_piece(factory.new_rook(colour),   File::File_h, rank)

      rank = Rank::Rank_7
      File.values.each do |file|
        self.place_piece(factory.new_pawn(colour), file, rank)
      end


      rank = Rank::Rank_2
      colour = Colour::White
      File.values.each do |file|
        self.place_piece(factory.new_pawn(colour), file, rank)
      end

      rank = Rank::Rank_1
      self.place_piece(factory.new_rook(colour),   File::File_a, rank)
      self.place_piece(factory.new_knight(colour), File::File_b, rank)
      self.place_piece(factory.new_bishop(colour), File::File_c, rank)
      self.place_piece(factory.new_queen(colour),  File::File_d, rank)
      self.place_piece(factory.new_king(colour),   File::File_e, rank)
      self.place_piece(factory.new_bishop(colour), File::File_f, rank)
      self.place_piece(factory.new_knight(colour), File::File_g, rank)
      self.place_piece(factory.new_rook(colour),   File::File_h, rank)

    end
    def clear_pieces
      File.values.each do |file|
        Rank.values.each do |rank|
          self.remove_piece file, rank
        end
      end
    end

    def possible_moves(piece_type, file, rank)
      assert_valid_file file
      assert_valid_rank rank
      assert_not_nil(self.piece_at(file, rank), "There is no piece to move at <#{file}>:<#{rank}>.")
      return self.send("possible_moves_for_#{piece_type.to_s.demodulized.downcase}", file, rank)
    end
    def possible_moves_for_king(file, rank)

      moves = []

      nxt_rank = rank.next
      prv_rank = rank.prev
      nxt_file = file.next
      prv_file = file.prev

      # North East
      if (!nxt_rank.nil? and !nxt_file.nil?)
        moves << factory.new_move(King, rank, file, nxt_rank, nxt_file, false)
      end

      # East
      if (!nxt_file.nil?)
        moves << factory.new_move(King, rank, file, rank, nxt_file, false)
      end

      # South East
      if (!prv_rank.nil? and !nxt_file.nil?)
        moves << factory.new_move(King, rank, file, prv_rank, nxt_file, false)
      end

      # South
      if (!prv_rank.nil?)
        moves << factory.new_move(King, rank, file, prv_rank, file, false)
      end

      # South West
      if (!prv_rank.nil? and !prv_file.nil?)
        moves << factory.new_move(King, rank, file, prv_rank, prv_file, false)
      end

      # West
      if (!prv_file.nil?)
        moves << factory.new_move(King, rank, file, rank, prv_file, false)
      end

      # North West
      if (!nxt_rank.nil? and !prv_file.nil?)
        moves << factory.new_move(King, rank, file, nxt_rank, prv_file, false)
      end

      # North
      if (!nxt_rank.nil?)
        moves << factory.new_move(King, rank, file, nxt_rank, file, false)
      end

      return moves
    end
    def possible_moves_for_queen(file, rank)
      moves = []

      # North East
      nxt_file = file.next
      nxt_rank = rank.next
      while (!nxt_file.nil? and !nxt_rank.nil?)
        moves << factory.new_move(Queen, rank, file, nxt_rank, nxt_file, false)
        nxt_file = nxt_file.next
        nxt_rank = nxt_rank.next
      end

      # East
      nxt_file = file.next
      while (!nxt_file.nil?)
        moves << factory.new_move(Queen, rank, file, rank, nxt_file, false)
        nxt_file = nxt_file.next
      end

      # South East
      nxt_file = file.next
      prv_rank = rank.prev
      while (!nxt_file.nil? and !prv_rank.nil?)
        moves << factory.new_move(Queen, rank, file, prv_rank, nxt_file, false)
        nxt_file = nxt_file.next
        prv_rank = prv_rank.prev
      end

      # South
      prv_rank = rank.prev
      while (!prv_rank.nil?)
        moves << factory.new_move(Queen, rank, file, prv_rank, file, false)
        prv_rank = prv_rank.prev
      end

      # South West
      prv_file = file.prev
      prv_rank = rank.prev
      while (!prv_file.nil? and !prv_rank.nil?)
        moves << factory.new_move(Queen, rank, file, prv_rank, prv_file, false)
        prv_file = prv_file.prev
        prv_rank = prv_rank.prev
      end

      # West
      prv_file = file.prev
      while (!prv_file.nil?)
        moves << factory.new_move(Queen, rank, file, rank, prv_file, false)
        prv_file = prv_file.prev
      end

      # North West
      prv_file = file.prev
      nxt_rank = rank.next
      while (!prv_file.nil? and !nxt_rank.nil?)
        moves << factory.new_move(Queen, rank, file, nxt_rank, prv_file, false)
        prv_file = prv_file.prev
        nxt_rank = nxt_rank.next
      end

      # North
      nxt_rank = rank.next
      while (!nxt_rank.nil?)
        moves << factory.new_move(Queen, rank, file, nxt_rank, file, false)
        nxt_rank = nxt_rank.next
      end

      return moves
    end
    def possible_moves_for_rook(file, rank)
      moves = []

      # East
      nxt_file = file.next
      while (!nxt_file.nil?)
        moves << factory.new_move(Rook, rank, file, rank, nxt_file, false)
        nxt_file = nxt_file.next
      end

      # South
      prv_rank = rank.prev
      while (!prv_rank.nil?)
        moves << factory.new_move(Rook, rank, file, prv_rank, file, false)
        prv_rank = prv_rank.prev
      end

      # West
      prv_file = file.prev
      while (!prv_file.nil?)
        moves << factory.new_move(Rook, rank, file, rank, prv_file, false)
        prv_file = prv_file.prev
      end

      # North
      nxt_rank = rank.next
      while (!nxt_rank.nil?)
        moves << factory.new_move(Rook, rank, file, nxt_rank, file, false)
        nxt_rank = nxt_rank.next
      end

      return moves
    end
    def possible_moves_for_bishop(file, rank)
      moves = []

      # North East
      nxt_file = file.next
      nxt_rank = rank.next
      while (!nxt_file.nil? and !nxt_rank.nil?)
        moves << factory.new_move(Rook, rank, file, nxt_rank, nxt_file, false)
        nxt_file = nxt_file.next
        nxt_rank = nxt_rank.next
      end

      # South East
      nxt_file = file.next
      prv_rank = rank.prev
      while (!nxt_file.nil? and !prv_rank.nil?)
        moves << factory.new_move(Rook, rank, file, prv_rank, nxt_file, false)
        nxt_file = nxt_file.next
        prv_rank = prv_rank.prev
      end

      # South West
      prv_file = file.prev
      prv_rank = rank.prev
      while (!prv_file.nil? and !prv_rank.nil?)
        moves << factory.new_move(Rook, rank, file, prv_rank, prv_file, false)
        prv_file = prv_file.prev
        prv_rank = prv_rank.prev
      end

      # North West
      prv_file = file.prev
      nxt_rank = rank.next
      while (!prv_file.nil? and !nxt_rank.nil?)
        moves << factory.new_move(Rook, rank, file, nxt_rank, prv_file, false)
        prv_file = prv_file.prev
        nxt_rank = nxt_rank.next
      end

      return moves
    end
    def possible_moves_for_knight(file, rank)
      moves = []
      [:NNE, :NEE, :SEE, :SSE, :SSW, :SWW, :NWW, :NNW].each do |direction|
        case direction
          when :NNE
            lfile = file.next
            lrank = rank.next.next
          when :NEE
            lfile = file.next.next
            lrank = rank.next
          when :SEE
            lfile = file.next.next
            lrank = rank.prev
          when :SSE
            lfile = file.next
            lrank = rank.prev.prev
          when :SSW
            lfile = file.prev
            lrank = rank.prev.prev
          when :SWW
            lfile = file.prev.prev
            lrank = rank.prev
          when :NWW
            lfile = file.prev.prev
            lrank = rank.next
          when :NNW
            lfile = file.prev
            lrank = rank.next.next
        end
        if (!lfile.nil? and !lrank.nil?)
          moves << factory.new_move(Knight, rank, file, lrank, lfile, false)
        end
      end
      return moves
    end
    def possible_moves_for_pawn(file, rank)
      moves = []
      nxt_file = file.next
      prv_file = file.prev
      nxt_rank = rank.next
      nxt_nxt_rank = nxt_rank.next

      # North East
      if !nxt_file.nil? and !nxt_rank.nil? and self.piece_at(nxt_file, nxt_rank)
        moves << factory.new_move(Pawn, file, rank, nxt_file, nxt_rank, true)
      end

      # North West
      if !prv_file.nil? and !nxt_rank.nil? and self.piece_at(prv_file, nxt_rank)
        moves << factory.new_move(Pawn, file, rank, prv_file, nxt_rank, true)
      end

      # North
      if !nxt_rank.nil? and self.piece_at(file, nxt_rank).nil?
        moves << factory.new_move(Pawn, file, rank, file, nxt_rank, false)
      end

      # North North
      if (!tracker.history(piece_at(file, rank)).moved_once?)
        if !nxt_nxt_rank.nil? and self.piece_at(file, nxt_nxt_rank).nil?
          moves << factory.new_move(Pawn, file, rank, file, nxt_nxt_rank, false)
        end
      end
      return moves
    end

    def move_piece(move)
      assert_valid_move(move)
      piece = square_at(move.from_file, move.from_rank).piece
      square_at(move.to_file, move.to_rank).piece = piece
      square_at(move.from_file, move.from_rank).piece = nil
      tracker.track(piece, move)
    end

    private

    def assert_valid_capture(capture, file, rank)
      piece = piece_at(file, rank)
      if (capture)
        assert_not_nil(piece, "No piece to capture at <#{rank.to_s.demodulized}:#{file.to_s.demodulized}>.")
      else
        assert_nil(piece, "Piece present at <#{rank.to_s.demodulized}:#{file.to_s.demodulized}>.  Must specify capture.")
      end
    end
    def assert_valid_move(move)
      assert_not_nil(move, "<nil> is not a valid move value.")
      assert_valid_rank(move.from_rank)
      assert_valid_file(move.from_file)
      assert_valid_rank(move.to_rank)
      assert_valid_file(move.to_file)
      assert_valid_piece_type(piece_at(move.from_file, move.from_rank).class, move.piece_type)
      assert_valid_capture(move.capture, move.to_file, move.to_rank)
    end
    def assert_valid_king_move
      assert_file(move.from_file)
      assert_rank(move.from_rank)
      assert_file(move.to_file)
      assert_rank(move.to_rank)
      assert_piece_type_matches(move.piece_type, move.from_file, move.from_rank)
      reachable = false
      allowed_paths = king_allowed_directions(move.from_file, move.from_rank)
      allowed_paths.each do |path|
        path.each do |position|

          # Position found on path -> no need to keep following the path
          if (position.file == move.to_file and position.rank == move.to_rank )
            reachable = true
            break
          end
        end

        # Position found on path -> no need to look at other paths
        if (reachable)
          break
        end
      end

      if (!reachable)
        raise AssertionFailedException, "Move unrechable"
      end
    end

  end
end
