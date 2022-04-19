import { act, renderHook } from "@testing-library/react-hooks";

import useThaiWin from "./useThaiWin";

import enterThaiWinAPI from "../../api/enterThaiWin";
import exitThaiWinAPI from "../../api/exitThaiWin";

jest.mock("../../api/enterThaiWin");
jest.mock("../../api/exitThaiWin");

describe("useThaiWin", () => {
  test("fully return;", () => {
    const { result } = renderHook(useThaiWin);

    expect(result.current).toEqual([expect.any(Boolean), expect.any(Function), expect.any(Function)]);
  });

  test("when enter once then exit once, should working correctly", () => {
    const { result } = renderHook(useThaiWin);
    const mockEnterThaiWinAPI = enterThaiWinAPI;
    const mockExitThaiWinAPI = exitThaiWinAPI;

    act(() => {
      result.current[1]();
    });

    expect(mockEnterThaiWinAPI).toHaveBeenCalledTimes(1);
    expect(mockExitThaiWinAPI).toHaveBeenCalledTimes(0);
    expect(result.current[0]).toEqual(true);

    act(() => {
      result.current[2]();
    });

    expect(mockEnterThaiWinAPI).toHaveBeenCalledTimes(1);
    expect(mockExitThaiWinAPI).toHaveBeenCalledTimes(1);
    expect(result.current[0]).toEqual(false);
  });

  test("when called the enter three times then exit once, should working correctly that call Enter API once and Call Exit API once", () => {
    const { result } = renderHook(useThaiWin);
    const mockEnterThaiWinAPI = enterThaiWinAPI;
    const mockExitThaiWinAPI = exitThaiWinAPI;

    act(() => {
      result.current[1]();
    });
    act(() => {
      result.current[1]();
    });
    act(() => {
      result.current[1]();
    });

    expect(mockEnterThaiWinAPI).toHaveBeenCalledTimes(1);
    expect(mockExitThaiWinAPI).toHaveBeenCalledTimes(0);
    expect(result.current[0]).toEqual(true);

    act(() => {
      result.current[2]();
    });

    expect(mockEnterThaiWinAPI).toHaveBeenCalledTimes(1);
    expect(mockExitThaiWinAPI).toHaveBeenCalledTimes(1);
    expect(result.current[0]).toEqual(false);
  });

  test("when enter once but forgot exit, should working correctly with call once Enter API then once Exit API", () => {
    const { result, unmount } = renderHook(useThaiWin);
    const mockEnterThaiWinAPI = enterThaiWinAPI;
    const mockExitThaiWinAPI = exitThaiWinAPI;

    act(() => {
      result.current[1]();
    });

    expect(mockEnterThaiWinAPI).toHaveBeenCalledTimes(1);
    expect(mockExitThaiWinAPI).toHaveBeenCalledTimes(0);
    expect(result.current[0]).toEqual(true);

    unmount();

    expect(mockEnterThaiWinAPI).toHaveBeenCalledTimes(1);
    expect(mockExitThaiWinAPI).toHaveBeenCalledTimes(1);
  });
});
