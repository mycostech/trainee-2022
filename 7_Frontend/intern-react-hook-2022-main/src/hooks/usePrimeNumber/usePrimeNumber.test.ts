import { act, renderHook } from "@testing-library/react-hooks";
import usePrimeNumber from "./usePrimeNumber";

describe("usePrimeNumber", () => {
  it("fully return;", () => {
    const { result } = renderHook(usePrimeNumber);

    expect(result.current).toEqual([expect.any(Boolean), expect.any(Function), expect.any(Number)]);
  });

  it("should check is Prime number correctly", () => {
    const { result } = renderHook(usePrimeNumber);

    act(() => {
      result.current[1](2);
    });
    expect(result.current[0]).toEqual(true);
    expect(result.current[2]).toEqual(2);

    act(() => {
      result.current[1](13);
    });
    expect(result.current[0]).toEqual(true);
    expect(result.current[2]).toEqual(13);

    act(() => {
      result.current[1](0);
    });
    expect(result.current[0]).toEqual(false);
    expect(result.current[2]).toEqual(0);

    act(() => {
      result.current[1](99);
    });
    expect(result.current[0]).toEqual(false);
    expect(result.current[2]).toEqual(99);

    act(() => {
      result.current[1](103);
    });
    expect(result.current[0]).toEqual(true);
    expect(result.current[2]).toEqual(103);

    act(() => {
      result.current[1](27);
    });
    expect(result.current[0]).toEqual(false);
    expect(result.current[2]).toEqual(27);

    act(() => {
      result.current[1](29);
    });
    expect(result.current[0]).toEqual(true);
    expect(result.current[2]).toEqual(29);

    act(() => {
      result.current[1](37);
    });
    expect(result.current[0]).toEqual(true);
    expect(result.current[2]).toEqual(37);
  });
});
