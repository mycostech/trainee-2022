import { useMemo, useState } from "react";

const calculateAgeOnCatPlanet = (age: number): number => {
  console.log("age will be calculated");
  return ((((age * 3) / 12) * 20) / 20) ^ 3;
};

function UseMemoExample() {
  const [name, setName] = useState<string>("");
  const [age, setAge] = useState<number>(12);

  const calculatedAge = useMemo(() => calculateAgeOnCatPlanet(age), [age]);

  return (
    <div>
      <p>Name</p>
      <input
        type="text"
        value={name}
        onChange={(e) => setName(e.target.value)}
      />
      <p>Age</p>
      <input
        type={"number"}
        value={age}
        onChange={(e) => setAge(parseInt(e.target.value))}
      />
      <p>Your Cat Planet age is: {calculatedAge}</p>
    </div>
  );
}

export default UseMemoExample;
