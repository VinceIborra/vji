$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'vji'

module Vji
  module Renum

    enum :TstEnum do
      Value1 'value1'
      Value2 'value2'
    end

    class EnumeratedValueTest < Test::Unit::TestCase

      def test_next
        assert_equal(TstEnum::Value2, TstEnum::Value1.next)
        assert_nil(TstEnum::Value2.next)
      end

      def test_prev
        assert_equal(TstEnum::Value1, TstEnum::Value2.prev)
        assert_nil(TstEnum::Value1.prev)
      end

    end

  end
end
