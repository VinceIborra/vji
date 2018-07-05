require 'vji/assertion_failed_exception'

module Vji
  module Assertions

    private
    
    def assert_nil(object, message)
      if (!object.nil?)
        raise AssertionFailedException, message
      end
    end

    def assert_not_nil(object, message)
      if (object.nil?)
        raise AssertionFailedException, message
      end
    end

  end
end