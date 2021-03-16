# ComicPeeps Documentation

---

### Contents:

- [Library Management](https://github.com/kitric/comicpeeps/blob/main/DOCUMENTATION.md#library-management)
- [Comic Reading](https://github.com/kitric/comicpeeps/blob/main/DOCUMENTATION.md#comic-reading)
- [Settings](https://github.com/kitric/comicpeeps/blob/main/DOCUMENTATION.md#settings)
- [Issue Tracking](https://github.com/kitric/comicpeeps/blob/main/DOCUMENTATION.md#issue-tracking)

---

### Library Management

ComicPeeps allows you to keep all of your comics in one application. It also keeps track of what comics you have read and bookmarks what pages you have read up to. However, there are certain ways in which you need to structure your file system in order for ComicPeeps to accurately sort all your comics.

This is what your file sytem should look like (the naming of the issues in this example does not matter):

```
comics/
   Absolute Carnage/
      issue1.cbr
      issue2.cbr
      issue3.cbz
   Venom (2018)/
      issue1.cbz
```

There are two ways in which you can add comics to your library; individually or whole directory.

**Adding comics individually**

This option allows you to choose individual comics to add to your library. Let's go back to the previous example. If I wanted to add `Absolute Carnage` to my library, I would choose the `Absolute Carnage/` folder. This will look for ALL CBR/CBZ files in that folder (and its sub-folders), then add them to your library under the name "Absolute Carnage". In this case, its added `issue1.cbr` , `issue2.cbr` and `issue3.cbz`  to my library as part of the Absolute Carnage comic.

**Adding comics via a directory**

This option allows you to add a whole directory to your library. This directory would be the place that you store all your comics. If we look at the example above the root directory is `comics/` so with this option I would choose that directory. It will first look for all sub-directories (in this case, it will find `Absolute Carnage/` and `Venom (108)/`) that haven't already been added as comics and will establish them as comics. Then it will look inside these libraries to find any CBR/CBZ files and add them as issues. However, this option can be **slow** depending on how many comics and issues you have stored in that directory.

**Naming conventions**

The name of your comic files/directories doesn't actually matter, as long as the issues are ordered accordingly. For example:

```
comics/
   Venom (2018)/
      Venom 2018 01.cbr
      Venom 2018 02.cbr
      Venom 2018 03.cbr
      Venom 2018 04.cbr
      Venom 2018 05.cbr
      Venom 2018 06.cbr
      ...
   ...
```

---

### Comic Reading

There are two ways you can open a comic file in ComicPeeps.

The first way is simple, just double click the homepage (the page with the ComicPeeps logo on it). However, it can be fairly annoying opening ComicPeeps every time you wanted to read a comic. So, you can also open it from the Windows File Explorer. ComicPeeps does not set itself as the default app for comic files. However there are a few ways to do this:

**Windows Settings app**

Click on the Windows Start button, and start typing `default apps`. Click on the first option, it should take you straight to the default apps section of the Windows Settings app. Then scroll to the bottom and click `Choose default applications by file type`. Look for CBR and/or CBZ, then click `Choose a default`. From there you can choose ComicPeeps, and now it will open automatically from your file explorer.

**File Explorer**

Click on the file you want to open. Then go to **Home > Open** > **Choose another app**. Then choose ComicPeeps from there. Remember to check "Always use this app to open this file", and it will set ComicPeeps as your default comic reader.

**File Types**

Currently, ComicPeeps only reads CBR and CBZ files. If you want to submit a new file type, then log it on the [GitHub Issue tracker](https://github.com/kitric/comicpeeps/issues), and I will review it and decide whether it should be implemented.

---

### Settings

The ComicPeeps settings page is where you can edit all your preferences for the application.

**Auto Flip Pages - Checkbox**

This will automatically flip your pages for you after a certain amount of time. This is effected by the Auto Flip Speed.

**Auto Flip Speed - Number**

The time in which the application will wait to turn your page (in seconds). This will only take affect when Auto Flip Pages is checked.

**Save Last Page - Checkbox**

Bookmarks your pages so you don't need to remember where you left on.

**Compress Size - Number**

The size of the pages will be divided by this much. For example, if Compress Size was 2, then the images will be half the size of the original image. The bigger the number, the lower the quality of the pages. The recommended size is 2.

**Page Results Size - Number**

The amount of results per page. This affects both the comics page and the issues page.

**Export Data - Multiple Choice**

This exports your data, excluding your settings.

**CSV** - Exports it in the CSV file format (comma separated values). Best shot if you just want a backup of your data.

**JSON** - Exports the data in JSON (JavaScript Object Notation). This is best for external integration with other applications.

**XML** - Exports it in XML. Again, this would probably be used for external integration.

---

### Issue Tracking

Found a bug, or have a recommendation? Post something on the [GitHub issues page](https://github.com/kitric/comicpeeps/issues)!