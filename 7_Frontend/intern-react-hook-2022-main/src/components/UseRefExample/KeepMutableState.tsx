import { useEffect, useRef } from "react";

function KeepMutableState() {
  const noChangeValue = useRef<number>(0);

  const increase = () => {
    noChangeValue.current += 10
  };

  useEffect(() => {
    console.log('no effect no effect')
  }, [noChangeValue])

  return (
    <div>
      <p>Count is: {noChangeValue.current}</p>
      <div>
        
        <button onClick={increase}>Plus + 1</button>
      </div>
    </div>
  );
}

export default KeepMutableState;
