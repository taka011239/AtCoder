import Data.Char

main = do
  name <- getLine
  putStrLn $ show $ count name

count :: String -> Int
count src = if isPalindrome src
            then len `div` 2 * 2 * 25
            else if isChangePalindrome src
                 then (len - 2) * 25 + 48
                 else len * 25
  where len = length src

isChangePalindrome :: String -> Bool
isChangePalindrome src = 2 == (length $ filter id $ zipWith (/=) src $ reverse src)

isPalindrome :: String -> Bool
isPalindrome src = src == reverse src


testCase1 :: Bool
testCase1 = count "S" == 0

testCase2 :: Bool
testCase2 = count "NOLEMONNOMELON" == 350
