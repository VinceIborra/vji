$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'vji'

module Vji
  class TestClass

    include Vji::Assertions

    def public_assert_nil(object, message)
      assert_nil object, message
    end

    def public_assert_not_nil(object, message)
      assert_not_nil object, message
    end

  end

  class AssertionsTest < Test::Unit::TestCase

    def test_assert_nil
      klass = TestClass.new
      assert_exception_raised "not a nil value" do
        klass.public_assert_nil :a_non_nil_value, "not a nil value"
      end
    end

    def test_assert_not_nil
      klass = TestClass.new
      assert_exception_raised "a nil value" do
        klass.public_assert_not_nil nil, "a nil value"
      end
    end

  end
end
