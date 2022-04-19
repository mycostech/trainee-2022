import { useState } from "react";
import SelectField from "./components/SelectField";
import Car from "./models/Car";

const cars: Car[] = [
  {
    type: "Repairing",
    model: "MG",
    year: 2021,
  },
  {
    type: "Family",
    model: "TOYOTA",
    year: 1994,
  },
  {
    type: "Sport",
    model: "HONDA",
    year: 2000,
  },
];

function App() {
  const [name, setName] = useState<string>("");
  const [carModel, setCarModel] = useState<string>();

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    alert(`Your name is ${name} want to buy the ${JSON.stringify(cars.find((f) => f.model === carModel))}`);
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label htmlFor="">Your name</label>
        <input type="text" value={name} onChange={(e) => setName(e.target.value)} />
      </div>
      <div>
        <SelectField
          label="Select a Car"
          items={cars}
          onSelect={(selectCar: string) => {
            console.log("selectCar selectCar: ", selectCar);
            setCarModel(selectCar);
          }}
        >
          {(item) => (
            <option key={item.model} value={item.model}>
              {item.model}
            </option>
          )}
        </SelectField>
      </div>
      <div>
        <button> Submit </button>
      </div>
    </form>
  );
}

export default App;
