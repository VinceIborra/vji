require 'mvc/command'
require 'mvc/arrange_command'
require 'mvc/move_command'
require 'mvc/exit_command'
require 'mvc/non_command'
require 'mvc/parser'
require 'mvc/renderer'
require 'mvc/controller'
require 'mvc/driver'

module Mvc
  class Factory

    def new_arrange_command
      command = ArrangeCommand.new
      return command
    end
    def new_move_command(move)
      command = MoveCommand.new
      command.move = move
      return command
    end
    def new_exit_command
      command = ExitCommand.new
      return command
    end
    def new_non_command(message)
      command = NonCommand.new
      command.message = message
      return command
    end

    def new_controller(board)
      controller = Controller.new
      controller.board = board
      return controller
    end
    def new_renderer
      renderer = Renderer.new
      return renderer
    end
    def new_parser(chess_factory)
      parser = Parser.new
      parser.factory = self
      parser.chess_factory = chess_factory
      return parser
    end
    def new_driver(board, parser, controller, renderer)
      driver = Driver.new
      driver.board = board
      driver.parser = parser
      driver.controller = controller
      driver.renderer = renderer
      return driver
    end
  end
end
