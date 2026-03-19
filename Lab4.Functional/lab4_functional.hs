isPrime :: Int -> Bool
isPrime n
    | n < 2 = False
    | otherwise = null [d | d <- [2 .. isqrt n], n `mod` d == 0]

isPerfect :: Int -> Bool
isPerfect n
    | n < 2 = False
    | otherwise = sum [d | d <- [1 .. n - 1], n `mod` d == 0] == n

isqrt :: Int -> Int
isqrt = floor . sqrt . fromIntegral

sumOfSquaresForPrimeOrPerfect :: Int -> Int
sumOfSquaresForPrimeOrPerfect upperLimit =
    sum [x * x | x <- [1 .. upperLimit], isPrime x || isPerfect x]

main :: IO ()
main = do
    putStr "Enter upper bound: "
    input <- getLine
    let upperLimit = read input :: Int
    if upperLimit < 1
        then putStrLn "Upper bound must be a positive integer."
        else putStrLn ("Sum of squares = " ++ show (sumOfSquaresForPrimeOrPerfect upperLimit))
