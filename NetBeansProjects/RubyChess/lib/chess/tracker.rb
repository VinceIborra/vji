require 'chess'

module Chess
  class Tracker

    attr_accessor :factory

    def initialize
      @histories = {}
    end

    def track(piece, move)
      if (histories[piece].nil?)
        histories[piece] = factory.new_history
      end
      histories[piece].track(move)
    end
    def history(piece)
      return histories[piece]
    end

    private
    attr_accessor :histories

  end
end
