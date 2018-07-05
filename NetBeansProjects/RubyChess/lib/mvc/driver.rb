require 'mvc/exit_command'

class Driver

  attr_accessor :board, :parser, :controller, :renderer

  def run
    
    # Output an introduction to the user
    print renderer.intro

    # Start off with an arranged board
    board.arrange_pieces
    
    # Keep processing input until done
    done = false
    while (!done)
      
      # Render the current state of the board
      print renderer.render(board)

      # Render any message from the controller
      print "\n\t#{controller.message}\n"

      # Output prompt
      print renderer.prompt

      # Get input
      str_command = gets.chomp
      command = parser.parse(str_command)
      
      # Process exit command
      if (command.kind_of?(ExitCommand))
        done = true
        next
      end
      
      # Otherwise let controller process all other commands
      controller.process_command(command)
    end
  end
end
