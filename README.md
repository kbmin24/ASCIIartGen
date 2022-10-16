# English
This is a ASCII Art genertor which gives you a HTML file from a image source & export path and image size.

## How does it work?
 * Before processing any image, it calcaulates the 'density' of image, by painting a character on a empty canvas and calculating the empty darkness.
 * Then characters are evenly sorted in the order of brightness.
 * Upon reading the source file, the program (i) processes EXIF file to rectify orientation and (ii) resizes the image.
 * Then for each pixel, the program calculates the closet 'match' by calculating the average brightness of that pixel as well.
 * If 'colour' mode is selected, colours is added by using CSS.

## Gallery
![](you_ascii.png)

![](dotnet_ascii.png)

The images are taken from Lovelive!! and Microsoft corp. No copyright infringement intended.
