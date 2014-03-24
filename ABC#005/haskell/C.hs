main :: IO()
main = do
  t <- readLn
  c <- readLn
  ts <- getLine
  n <- readLn
  ws <- getLine
  let tss = map read $ take c $ words ts :: [Int]
  let wss = map read $ take n $ words ws :: [Int]
  if isSell t tss wss
     then putStrLn "yes"
     else putStrLn "no"

isSell :: Int -> [Int] -> [Int] -> Bool
isSell _ _ [] = True
isSell _ [] _ = False
isSell t (x:xs) ws@(y:ys) = if x > y then False
                            else if abs(x - y) <= t
                                 then isSell t xs ys
                                 else isSell t xs ws

