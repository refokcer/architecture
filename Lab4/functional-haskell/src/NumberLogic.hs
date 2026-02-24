module NumberLogic
  ( isPrime,
    isPerfect,
    sumOfSquaresForPrimeOrPerfect
  )
where

isPrime :: Int -> Bool
isPrime n
  | n < 2 = False
  | otherwise = null [d | d <- [2 .. isqrt n], n `mod` d == 0]

isPerfect :: Int -> Bool
isPerfect n
  | n < 2 = False
  | otherwise = sum properDivisors == n
  where
    properDivisors = [d | d <- [1 .. n - 1], n `mod` d == 0]

sumOfSquaresForPrimeOrPerfect :: Int -> Integer
sumOfSquaresForPrimeOrPerfect upper =
  sum [fromIntegral (x * x) | x <- [1 .. upper], isPrime x || isPerfect x]

isqrt :: Int -> Int
isqrt = floor . sqrt . (fromIntegral :: Int -> Double)
