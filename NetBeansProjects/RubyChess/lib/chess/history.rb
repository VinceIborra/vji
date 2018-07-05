require 'chess'

module Chess
  class History

    attr_accessor :moved_once

    def moved_once?
      return moved_once
    end

    def track(event)
      if (event.kind_of?(Move))
        self.moved_once = true
      end
    end

  end
end
