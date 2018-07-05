class Square

  attr_accessor :rank, :file, :shade, :piece

  def ==(square)
    return false if (square.nil?)
    return false if (!square.kind_of?(self.class))
    return false if (square.rank != self.rank)
    return false if (square.file != self.file)
    return false if (square.shade != self.shade)
    return true
  end

end
