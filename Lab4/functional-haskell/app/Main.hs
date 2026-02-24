module Main where

import NumberLogic (sumOfSquaresForPrimeOrPerfect)
import Text.Read (readMaybe)

main :: IO ()
main = do
  putStr "Enter upper bound: "
  input <- getLine
  case readMaybe input :: Maybe Int of
    Just upperLimit | upperLimit > 0 -> printResult upperLimit
    _ -> putStrLn "Upper bound must be a positive integer."

printResult :: Int -> IO ()
printResult upperLimit = do
  let result = sumOfSquaresForPrimeOrPerfect upperLimit
  putStrLn $ "Sum of squares = " ++ show result
