$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'vji'

module Vji
  class AssertionFailedExceptionTest < Test::Unit::TestCase

    attr_reader :factory

    def setup
      @factory = Factory.new
    end

    def test_message_attribute
      exception = factory.new_assertion_failed_exception("some message")
      assert_equal("some message", exception.message)
    end
  end
end
