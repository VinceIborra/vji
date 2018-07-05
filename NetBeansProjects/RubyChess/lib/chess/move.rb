module Chess
  class Move

    attr_accessor :piece_type, :from_rank, :from_file, :to_rank, :to_file, :capture

    def ==(move)
      return false if (move.nil?)
      return false if (!move.kind_of?(self.class))
      return false if (move.piece_type != self.piece_type)
      return false if (move.from_rank != self.from_rank)
      return false if (move.from_file != self.from_file)
      return false if (move.to_rank != self.to_rank)
      return false if (move.to_file != self.to_file)
      return false if (move.capture != self.capture)
      return true
    end

  end
end
