main = do
  price <- getLine
  putStrLn $ convert price

convert :: String -> String
convert "" = ""
convert (x:xs) = change x : (convert xs)
    where change :: Char -> Char
          change 'O' = '0'
          change 'D' = '0'
          change 'I' = '1'
          change 'Z' = '2'
          change 'S' = '5'
          change 'B' = '8'
          change  c  = c

testCase1 :: Bool
testCase1 = convert "1Z0" == "120"

testCase2 :: Bool
testCase2 = convert "4ZD60" == "42060"

testCase3 :: Bool
testCase3 = convert "BI9Z" == "8192"

