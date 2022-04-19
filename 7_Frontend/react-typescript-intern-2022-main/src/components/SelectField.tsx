import { ReactNode } from "react";
import Car from "../models/Car";

interface SelectFieldProps {
  items: Car[];
  onSelect: (selectId: string) => void;
  children: (item: Car) => ReactNode;
  label?: string;
}

function SelectField({ label, items, children, onSelect }: SelectFieldProps) {
  const handleChange = (item: string) => {
    onSelect(item);
  };
  return (
    <>
      <label htmlFor="">{label}</label>
      <select
        onChange={(e) => {
          handleChange(e.target.value);
        }}
      >
        {items.map((m) => children(m))}
      </select>
    </>
  );
}

export default SelectField;
