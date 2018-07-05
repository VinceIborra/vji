module Renum

  class EnumeratedValue

    def next
      if (self.index >= self.class.values.length)
        return nil
      else
        return self.class[self.index+1]
      end
    end

    def prev
      if (self.index <= 0)
        return nil
      else
        return self.class[self.index-1]
      end
    end

  end

end
