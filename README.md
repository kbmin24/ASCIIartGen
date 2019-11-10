# English
This is a ASCII Art genertor which gives you a HTML file from a image source & export path and image size. ~~This was just made for a experiment. Dont even expect a single exception handling~~

Both black/white mode and colour modes are available,however html exported with colour mode takes few minutes to load(with an example of 800x1200 image) and consumes 2GB of RAM with a somewhat modern system with Ryzen 5 3600 and 16GB of RAM. Black&White mode is way better in this aspect.
# Korean
예전 컴에서 발굴한 아스키 아트 생성기입니다. 지시대로 이미지 source 및 export 경로, 해상도 등 입력하면 결과물을 HTML 파일로 뱉어줍니다. 대충 만든 것이기에 예외 처리 등은 기대도 하지 마세요.

흑백모드와 칼라모드가 있는데, 칼라모드는 픽셀당 span element 하나를 생성해서 하는 무식한 방식인 관계로, 웹브라우저 로딩이 매우 느립니다. 800x1200 정도 되는 이미지 기준 Ryzen 5 3600에 RAM 16GB 달고 있는 컴퓨터에서도 로딩이 수 분 걸리며 램도 2GB 가량 집어먹습니다. 흑백 모드는 그나마 낫습니다.

# Mechanism
As the program launches, it creates a image with pre-defined list of characters, and create a list of their average "brightness" with the pixels' RGB values. Than, when it goes through the image pixels, it finds appropriate character that is in similar brightness.
