import { useEffect, useRef, useState } from "react";

function TrackPreviousState() {
  const [inputValue, setInputValue] = useState<string>("");

  const previousInputRef = useRef<string>("");

  useEffect(() => {
    previousInputRef.current = inputValue;
  }, [inputValue]);

  return (
    <>
      <input
        type="text"
        value={inputValue}
        onChange={(e) => setInputValue(e.target.value)}
      />
      <h2>Current Value: {inputValue}</h2>
      <h2>Previous Value: {previousInputRef.current}</h2>
    </>
  );
}

export default TrackPreviousState;
