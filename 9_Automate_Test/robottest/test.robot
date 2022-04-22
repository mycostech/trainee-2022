*** Settings ***
Library     Selenium2Library

*** Variables ***
${BROWSER}      chrome
${URL}          http://www.google.com


*** Keywords ***
Open google
    Open browser    ${URL}      ${BROWSER}
Search for
    [Arguments]     ${SEARCH_TERM}
    Input Text      q      ${SEARCH_TERM}
    Press Keys    q     ENTER
    Wait Until Page Contains     test

*** Test Cases ***
Test google search
    Open google
    Search for    test