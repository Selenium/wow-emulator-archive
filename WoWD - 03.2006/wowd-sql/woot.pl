#!/usr/bin/perl

opendir(DIR,".");
@files = readdir(DIR);
closedir DIR;

foreach $file (@files) {
	next if ($file =~ /^\./);
	next if ($file !~ /\.sql$/i);
	print "source ".$file.";\n";
}